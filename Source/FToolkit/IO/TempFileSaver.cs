using FToolkit.Objects;

namespace FToolkit.IO;

/// <summary>
/// 一時ディレクトリにファイルを保存するクラスです。
/// </summary>
public sealed class TempFileSaver : ITempFileSaver
{
    static readonly SemaphoreSlim ReadWriteLock = new(1);

    readonly IFileOperations _fileOperations;
    readonly IDirectoryOperations _directoryOperations;

    /// <summary>
    /// <see cref="TempFileSaver"/>クラスの新しいインスタンスを初期化します。
    /// </summary>
    /// <param name="fileOperations">ファイル操作を行うクラス</param>
    /// <param name="directoryOperations">ディレクトリ操作を行うクラス</param>
    public TempFileSaver(IFileOperations fileOperations, IDirectoryOperations directoryOperations)
    {
        ArgumentNullException.ThrowIfNull(fileOperations);
        ArgumentNullException.ThrowIfNull(directoryOperations);

        _fileOperations = fileOperations;
        _directoryOperations = directoryOperations;
    }

    /// <inheritdoc/>
    public async ValueTask<FilePath> ExecuteAsync(DirectoryName parentDirectoryName, FileName fileName, ReadOnlyMemory<byte> bytes, CancellationToken cancellationToken = default)
    {
        var tempDirectoryPath = Path.Join(Path.GetTempDirectoryPath(), parentDirectoryName);
        var outputFilePath = Path.Join(tempDirectoryPath, fileName);

        await ReadWriteLock.WaitAsync(cancellationToken).ConfigureAwait(false);

        try
        {
            _directoryOperations.Create(tempDirectoryPath);
            await _fileOperations.SaveAsync(outputFilePath, bytes, cancellationToken).ConfigureAwait(false);
        }
        finally
        {
            ReadWriteLock.Release();
        }

        return outputFilePath;
    }

    /// <inheritdoc/>
    public async ValueTask<FilePath> ExecuteAsync(DirectoryName parentDirectoryName, FileName fileName, ReadOnlyMemory<char> chars, CancellationToken cancellationToken = default)
    {
        var tempDirectoryPath = Path.Join(Path.GetTempDirectoryPath(), parentDirectoryName);
        var outputFilePath = Path.Join(tempDirectoryPath, fileName);

        await ReadWriteLock.WaitAsync(cancellationToken).ConfigureAwait(false);

        try
        {
            _directoryOperations.Create(tempDirectoryPath);
            await _fileOperations.SaveAsync(outputFilePath, chars, cancellationToken).ConfigureAwait(false);
        }
        finally
        {
            ReadWriteLock.Release();
        }

        return outputFilePath;
    }
}
