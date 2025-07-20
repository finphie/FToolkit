using System.Text;
using CommunityToolkit.HighPerformance.Buffers;
using FToolkit.Objects;
using Microsoft.Extensions.Logging;

namespace FToolkit.IO;

/// <summary>
/// ファイル操作を行うクラスです。
/// </summary>
public sealed partial class FileOperations : IFileOperations
{
    readonly ILogger<FileOperations> _logger;

    /// <summary>
    /// <see cref="FileOperations"/>クラスの新しいインスタンスを初期化します。
    /// </summary>
    /// <param name="logger">ロガー</param>
    /// <exception cref="ArgumentNullException"><paramref name="logger"/>がnullです。</exception>
    public FileOperations(ILogger<FileOperations> logger)
    {
        ArgumentNullException.ThrowIfNull(logger);
        _logger = logger;
    }

    /// <inheritdoc/>
    public bool Exists(FilePath filePath)
    {
        LogCheckingExists(filePath);
        return File.Exists(filePath.AsPrimitive());
    }

    /// <inheritdoc/>
    public void Create(FilePath filePath, ReadOnlySpan<byte> bytes)
    {
        LogCreating(filePath);

        try
        {
            Write(filePath, bytes, FileMode.Create);
        }
        catch (Exception ex)
        {
            LogCouldNotCreateFile(filePath, ex);
            throw;
        }
    }

    /// <inheritdoc/>
    public void Create(FilePath filePath, ReadOnlySpan<char> chars)
    {
        var byteCount = Encoding.UTF8.GetMaxByteCount(chars.Length);
        using var buffer = SpanOwner<byte>.Allocate(byteCount);

        var destination = buffer.Span;
        var writtenCount = Encoding.UTF8.GetBytes(chars, destination);

        Create(filePath, destination[..writtenCount]);
    }

    /// <inheritdoc/>
    public void Save(FilePath filePath, ReadOnlySpan<byte> bytes)
    {
        LogSaving(filePath);

        try
        {
            Write(filePath, bytes, FileMode.CreateNew);
        }
        catch (Exception ex)
        {
            LogCouldNotSaveFile(filePath, ex);
            throw;
        }
    }

    /// <inheritdoc/>
    public void Save(FilePath filePath, ReadOnlySpan<char> chars)
    {
        var byteCount = Encoding.UTF8.GetMaxByteCount(chars.Length);
        using var buffer = SpanOwner<byte>.Allocate(byteCount);

        var destination = buffer.Span;
        var writtenCount = Encoding.UTF8.GetBytes(chars, destination);

        Save(filePath, destination[..writtenCount]);
    }

    /// <inheritdoc/>
    public void Delete(FilePath filePath)
    {
        if (!Exists(filePath))
        {
            return;
        }

        LogDeleting(filePath);

        try
        {
            File.Delete(filePath.AsPrimitive());
        }
        catch (Exception ex)
        {
            LogCouldNotDeleteFile(filePath, ex);
            throw;
        }
    }

    static void Write(FilePath filePath, ReadOnlySpan<byte> bytes, FileMode mode)
    {
        using var handle = File.OpenHandle(filePath.AsPrimitive(), mode, FileAccess.Write);
        RandomAccess.Write(handle, bytes, 0);
    }

    [LoggerMessage(Level = LogLevel.Information, Message = "Checking if file exists: {filePath}")]
    partial void LogCheckingExists(FilePath filePath);

    [LoggerMessage(Level = LogLevel.Information, Message = "Creating file: {filePath}")]
    partial void LogCreating(FilePath filePath);

    [LoggerMessage(Level = LogLevel.Information, Message = "Saving file: {filePath}")]
    partial void LogSaving(FilePath filePath);

    [LoggerMessage(Level = LogLevel.Information, Message = "Deleting file: {filePath}")]
    partial void LogDeleting(FilePath filePath);

    [LoggerMessage(Level = LogLevel.Warning, Message = "Could not create file: {filePath}")]
    partial void LogCouldNotCreateFile(FilePath filePath, Exception ex);

    [LoggerMessage(Level = LogLevel.Warning, Message = "Could not save file: {filePath}")]
    partial void LogCouldNotSaveFile(FilePath filePath, Exception ex);

    [LoggerMessage(Level = LogLevel.Warning, Message = "Could not delete file: {filePath}")]
    partial void LogCouldNotDeleteFile(FilePath filePath, Exception ex);
}
