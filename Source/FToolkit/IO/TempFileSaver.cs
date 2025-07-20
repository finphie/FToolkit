using FToolkit.Objects;

namespace FToolkit.IO;

/// <summary>
/// 一時ディレクトリにファイルを保存するクラスです。
/// </summary>
public sealed class TempFileSaver : ITempFileSaver
{
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
    public void Execute(DirectoryName parentDirectoryName, FileName fileName, ReadOnlySpan<byte> bytes)
    {
        var tempDirectoryPath = Path.Join(Path.GetTempDirectoryPath(), parentDirectoryName);
        _directoryOperations.Create(tempDirectoryPath);

        var tempFilePath = Path.Join(tempDirectoryPath, fileName);
        _fileOperations.Save(tempFilePath, bytes);
    }

    /// <inheritdoc/>
    public void Execute(DirectoryName parentDirectoryName, FileName fileName, ReadOnlySpan<char> chars)
    {
        var tempDirectoryPath = Path.Join(Path.GetTempDirectoryPath(), parentDirectoryName);
        _directoryOperations.Create(tempDirectoryPath);

        var tempFilePath = Path.Join(tempDirectoryPath, fileName);
        _fileOperations.Save(tempFilePath, chars);
    }
}
