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
    public void Execute(DirectoryName parentDirectoryName, FileName fileName, ReadOnlySpan<byte> bytes, out FilePath outputFilePath)
    {
        var tempDirectoryPath = Path.Join(Path.GetTempDirectoryPath(), parentDirectoryName);
        _directoryOperations.Create(tempDirectoryPath);

        outputFilePath = Path.Join(tempDirectoryPath, fileName);
        _fileOperations.Save(outputFilePath, bytes);
    }

    /// <inheritdoc/>
    public void Execute(DirectoryName parentDirectoryName, FileName fileName, ReadOnlySpan<char> chars, out FilePath outputFilePath)
    {
        var tempDirectoryPath = Path.Join(Path.GetTempDirectoryPath(), parentDirectoryName);
        _directoryOperations.Create(tempDirectoryPath);

        outputFilePath = Path.Join(tempDirectoryPath, fileName);
        _fileOperations.Save(outputFilePath, chars);
    }
}
