using Microsoft.Extensions.Logging;

namespace FToolkit.IO;

/// <summary>
/// ファイル操作を行うクラスです。
/// </summary>
public sealed partial class FileOperations : IFileOperations
{
    readonly ILogger _logger;

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

        Creating(filePath);

        try
        {
            Write(filePath, bytes, FileMode.Create);
        }
        catch (Exception ex)
        {
            CouldNotCreateFile(filePath, ex);
            throw;
        }
    }

    /// <inheritdoc/>
    public void Save(string filePath, ReadOnlySpan<byte> bytes)
    {
        ArgumentNullException.ThrowIfNull(filePath);

        Saving(filePath);

        try
        {
            Write(filePath, bytes, FileMode.CreateNew);
        }
        catch (Exception ex)
        {
            CouldNotSaveFile(filePath, ex);
            throw;
        }
    }

    /// <inheritdoc/>
    public void Delete(string filePath)
    {
        ArgumentNullException.ThrowIfNull(filePath);

        Deleting(filePath);

        if (File.Exists(filePath))
        {
            try
            {
                File.Delete(filePath);
            }
            catch (Exception ex)
            {
                CouldNotDeleteFile(filePath, ex);
                throw;
            }
        }
    }

    static void Write(string filePath, ReadOnlySpan<byte> bytes, FileMode mode)
    {
        using var handle = File.OpenHandle(filePath, mode, FileAccess.Write);
        RandomAccess.Write(handle, bytes, 0);
    }

    [LoggerMessage(EventId = 1, Level = LogLevel.Information, Message = "Creating file: {filePath}")]
    partial void Creating(string filePath);

    [LoggerMessage(EventId = 2, Level = LogLevel.Information, Message = "Saving file: {filePath}")]
    partial void Saving(string filePath);

    [LoggerMessage(EventId = 3, Level = LogLevel.Information, Message = "Deleting file: {filePath}")]
    partial void Deleting(string filePath);

    [LoggerMessage(EventId = 5001, Level = LogLevel.Warning, Message = "Could not create file: {filePath}")]
    partial void CouldNotCreateFile(string filePath, Exception ex);

    [LoggerMessage(EventId = 5002, Level = LogLevel.Warning, Message = "Could not save file: {filePath}")]
    partial void CouldNotSaveFile(string filePath, Exception ex);

    [LoggerMessage(EventId = 5003, Level = LogLevel.Warning, Message = "Could not delete file: {filePath}")]
    partial void CouldNotDeleteFile(string filePath, Exception ex);
}
