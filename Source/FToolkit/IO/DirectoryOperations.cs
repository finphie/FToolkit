using FToolkit.Objects;
using Microsoft.Extensions.Logging;

namespace FToolkit.IO;

/// <summary>
/// ディレクトリ操作を行うクラスです。
/// </summary>
public sealed partial class DirectoryOperations : IDirectoryOperations
{
    readonly ILogger<DirectoryOperations> _logger;

    /// <summary>
    /// <see cref="DirectoryOperations"/>クラスの新しいインスタンスを初期化します。
    /// </summary>
    /// <param name="logger">ロガー</param>
    /// <exception cref="ArgumentNullException"><paramref name="logger"/>がnullです。</exception>
    public DirectoryOperations(ILogger<DirectoryOperations> logger)
    {
        ArgumentNullException.ThrowIfNull(logger);
        _logger = logger;
    }

    /// <inheritdoc/>
    public bool Exists(DirectoryPath directoryPath)
    {
        LogCheckingExists(directoryPath);
        return Directory.Exists(directoryPath.AsPrimitive());
    }

    /// <inheritdoc/>
    public void Create(DirectoryPath directoryPath)
    {
        if (Exists(directoryPath))
        {
            return;
        }

        LogCreating(directoryPath);

        try
        {
            Directory.CreateDirectory(directoryPath.AsPrimitive());
        }
        catch (Exception ex)
        {
            LogCouldNotCreateDirectory(directoryPath, ex);
            throw;
        }
    }

    [LoggerMessage(Level = LogLevel.Information, Message = "Checking if file exists: {directoryPath}")]
    partial void LogCheckingExists(DirectoryPath directoryPath);

    [LoggerMessage(Level = LogLevel.Information, Message = "Creating directory: {directoryPath}")]
    partial void LogCreating(DirectoryPath directoryPath);

    [LoggerMessage(Level = LogLevel.Error, Message = "Could not create directory: {directoryPath}")]
    partial void LogCouldNotCreateDirectory(DirectoryPath directoryPath, Exception exception);
}
