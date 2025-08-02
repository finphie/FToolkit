using System.Text;
using CommunityToolkit.HighPerformance.Buffers;
using FToolkit.Objects;
using Microsoft.Extensions.Logging;

namespace FToolkit.IO;

/// <summary>
/// ファイル操作を行うクラスです。
/// </summary>
public sealed partial class FileOperations : IFileOperations, IDisposable
{
    readonly SemaphoreSlim _readWriteLock = new(1);
    readonly ILogger<FileOperations> _logger;

    /// <summary>
    /// <see cref="FileOperations"/>クラスの新しいインスタンスを初期化します。
    /// </summary>
    /// <param name="logger">ログ記録のためのオブジェクト</param>
    /// <exception cref="ArgumentNullException"><paramref name="logger"/>がnullです。</exception>
    public FileOperations(ILogger<FileOperations> logger)
    {
        ArgumentNullException.ThrowIfNull(logger);
        _logger = logger;
    }

    /// <inheritdoc/>
    public void Dispose()
        => _readWriteLock.Dispose();

    /// <inheritdoc/>
    public bool Exists(FilePath filePath)
    {
        LogCheckingExists(filePath);
        return File.Exists(filePath.AsPrimitive());
    }

    /// <inheritdoc/>
    public ValueTask CreateAsync(FilePath filePath, ReadOnlyMemory<byte> bytes, CancellationToken cancellationToken = default)
    {
        LogCreating(filePath);
        return WriteAsync(filePath, FileMode.CreateNew, bytes, cancellationToken);
    }

    /// <inheritdoc/>
    public async ValueTask CreateAsync(FilePath filePath, ReadOnlyMemory<char> chars, CancellationToken cancellationToken = default)
    {
        var byteCount = Encoding.UTF8.GetMaxByteCount(chars.Length);
        using var buffer = MemoryOwner<byte>.Allocate(byteCount);

        var writtenCount = Encoding.UTF8.GetBytes(chars.Span, buffer.Span);
        await CreateAsync(filePath, buffer.Memory[..writtenCount], cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public ValueTask SaveAsync(FilePath filePath, ReadOnlyMemory<byte> bytes, CancellationToken cancellationToken = default)
    {
        LogSaving(filePath);
        return WriteAsync(filePath, FileMode.Create, bytes, cancellationToken);
    }

    /// <inheritdoc/>
    public async ValueTask SaveAsync(FilePath filePath, ReadOnlyMemory<char> chars, CancellationToken cancellationToken = default)
    {
        var byteCount = Encoding.UTF8.GetMaxByteCount(chars.Length);
        using var buffer = MemoryOwner<byte>.Allocate(byteCount);

        var writtenCount = Encoding.UTF8.GetBytes(chars.Span, buffer.Span);
        await SaveAsync(filePath, buffer.Memory[..writtenCount], cancellationToken).ConfigureAwait(false);
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

    async ValueTask WriteAsync(FilePath filePath, FileMode mode, ReadOnlyMemory<byte> bytes, CancellationToken cancellationToken)
    {
        using var handle = File.OpenHandle(filePath.AsPrimitive(), mode, FileAccess.Write);
        await _readWriteLock.WaitAsync(cancellationToken).ConfigureAwait(false);

        try
        {
            await RandomAccess.WriteAsync(handle, bytes, 0, cancellationToken).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            LogCouldNotWriteFile(filePath, ex);
            throw;
        }
        finally
        {
            _readWriteLock.Release();
        }
    }

    [LoggerMessage(Level = LogLevel.Information, Message = "Checking if file exists: {filePath}")]
    partial void LogCheckingExists(FilePath filePath);

    [LoggerMessage(Level = LogLevel.Information, Message = "Creating file: {filePath}")]
    partial void LogCreating(FilePath filePath);

    [LoggerMessage(Level = LogLevel.Information, Message = "Saving file: {filePath}")]
    partial void LogSaving(FilePath filePath);

    [LoggerMessage(Level = LogLevel.Information, Message = "Deleting file: {filePath}")]
    partial void LogDeleting(FilePath filePath);

    [LoggerMessage(Level = LogLevel.Warning, Message = "Could not write to file: {filePath}")]
    partial void LogCouldNotWriteFile(FilePath filePath, Exception ex);

    [LoggerMessage(Level = LogLevel.Warning, Message = "Could not delete file: {filePath}")]
    partial void LogCouldNotDeleteFile(FilePath filePath, Exception ex);
}
