using System.Text;
using CommunityToolkit.HighPerformance.Buffers;
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
    public void Create(string filePath, ReadOnlySpan<byte> bytes)
    {
        ArgumentNullException.ThrowIfNull(filePath);
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
    public void Create(string filePath, ReadOnlySpan<char> chars)
    {
        var byteCount = Encoding.UTF8.GetMaxByteCount(chars.Length);
        using var buffer = SpanOwner<byte>.Allocate(byteCount);

        var destination = buffer.Span;
        var writtenCount = Encoding.UTF8.GetBytes(chars, destination);

        Create(filePath, destination[..writtenCount]);
    }

    /// <inheritdoc/>
    public void Create(FilePath filePath, ReadOnlySpan<byte> bytes)
        => Create(filePath.AsPrimitive(), bytes);

    /// <inheritdoc/>
    public void Create(FilePath filePath, ReadOnlySpan<char> chars)
        => Create(filePath.AsPrimitive(), chars);

    /// <inheritdoc/>
    public void Save(string filePath, ReadOnlySpan<byte> bytes)
    {
        ArgumentNullException.ThrowIfNull(filePath);
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
    public void Save(string filePath, ReadOnlySpan<char> chars)
    {
        var byteCount = Encoding.UTF8.GetMaxByteCount(chars.Length);
        using var buffer = SpanOwner<byte>.Allocate(byteCount);

        var destination = buffer.Span;
        var writtenCount = Encoding.UTF8.GetBytes(chars, destination);

        Save(filePath, destination[..writtenCount]);
    }

    /// <inheritdoc/>
    public void Save(FilePath filePath, ReadOnlySpan<byte> bytes)
        => Save(filePath.AsPrimitive(), bytes);

    /// <inheritdoc/>
    public void Save(FilePath filePath, ReadOnlySpan<char> chars)
        => Save(filePath.AsPrimitive(), chars);

    /// <inheritdoc/>
    public void Delete(string filePath)
    {
        ArgumentNullException.ThrowIfNull(filePath);
        LogDeleting(filePath);

        if (!File.Exists(filePath))
        {
            return;
        }

        try
        {
            File.Delete(filePath);
        }
        catch (Exception ex)
        {
            LogCouldNotDeleteFile(filePath, ex);
            throw;
        }
    }

    /// <inheritdoc/>
    public void Delete(FilePath filePath)
        => Delete(filePath.AsPrimitive());

    static void Write(string filePath, ReadOnlySpan<byte> bytes, FileMode mode)
    {
        using var handle = File.OpenHandle(filePath, mode, FileAccess.Write);
        RandomAccess.Write(handle, bytes, 0);
    }

    [LoggerMessage(Level = LogLevel.Information, Message = "Creating file: {filePath}")]
    partial void LogCreating(string filePath);

    [LoggerMessage(Level = LogLevel.Information, Message = "Saving file: {filePath}")]
    partial void LogSaving(string filePath);

    [LoggerMessage(Level = LogLevel.Information, Message = "Deleting file: {filePath}")]
    partial void LogDeleting(string filePath);

    [LoggerMessage(Level = LogLevel.Warning, Message = "Could not create file: {filePath}")]
    partial void LogCouldNotCreateFile(string filePath, Exception ex);

    [LoggerMessage(Level = LogLevel.Warning, Message = "Could not save file: {filePath}")]
    partial void LogCouldNotSaveFile(string filePath, Exception ex);

    [LoggerMessage(Level = LogLevel.Warning, Message = "Could not delete file: {filePath}")]
    partial void LogCouldNotDeleteFile(string filePath, Exception ex);
}
