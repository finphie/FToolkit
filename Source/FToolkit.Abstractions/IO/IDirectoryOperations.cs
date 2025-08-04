using FToolkit.Objects;

namespace FToolkit.IO;

/// <summary>
/// ディレクトリ操作に関する定義です。
/// </summary>
public interface IDirectoryOperations
{
    /// <summary>
    /// 指定したディレクトリが存在するかどうかを判定します。
    /// </summary>
    /// <param name="directoryPath">存在確認を行うディレクトリのパス</param>
    /// <returns>指定されたディレクトリが存在する場合は<see langword="true"/>、それ以外の場合は <see langword="false"/>を返します。</returns>
    bool Exists(DirectoryPath directoryPath);

    /// <summary>
    /// ディレクトリを作成します。
    /// </summary>
    /// <param name="directoryPath">ディレクトリのパス</param>
    /// <inheritdoc cref="Directory.CreateDirectory(string)" path="/exception"/>
    void Create(DirectoryPath directoryPath);
}
