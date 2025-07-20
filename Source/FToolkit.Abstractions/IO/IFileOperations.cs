using FToolkit.Objects;

namespace FToolkit.IO;

/// <summary>
/// ファイル操作に関する定義です。
/// </summary>
public interface IFileOperations
{
    /// <summary>
    /// 指定されたファイルが存在するかどうかを判定します。
    /// </summary>
    /// <param name="filePath">存在確認を行うファイルのパス</param>
    /// <returns>指定されたファイルが存在する場合は<see langword="true"/>、それ以外の場合は <see langword="false"/>を返します。</returns>
    bool Exists(FilePath filePath);

    /// <summary>
    /// ファイルを新規作成します。
    /// </summary>
    /// <param name="filePath">ファイルパス</param>
    /// <param name="bytes">データ</param>
    /// <inheritdoc cref="File.Create(string)" path="/exception"/>
    void Create(FilePath filePath, ReadOnlySpan<byte> bytes);

    /// <summary>
    /// ファイルを新規作成します。
    /// </summary>
    /// <param name="filePath">ファイルパス</param>
    /// <param name="chars">データ</param>
    /// <inheritdoc cref="Create(FilePath, ReadOnlySpan{byte})" path="/exception"/>
    void Create(FilePath filePath, ReadOnlySpan<char> chars);

    /// <summary>
    /// ファイルに上書き保存します。
    /// </summary>
    /// <param name="filePath">ファイルパス</param>
    /// <param name="bytes">データ</param>
    /// <inheritdoc cref="Create(FilePath, ReadOnlySpan{byte})" path="/exception"/>
    void Save(FilePath filePath, ReadOnlySpan<byte> bytes);

    /// <summary>
    /// ファイルに上書き保存します。
    /// </summary>
    /// <param name="filePath">ファイルパス</param>
    /// <param name="chars">データ</param>
    /// <inheritdoc cref="Save(FilePath, ReadOnlySpan{byte})" path="/exception"/>
    void Save(FilePath filePath, ReadOnlySpan<char> chars);

    /// <summary>
    /// ファイルを削除します。
    /// </summary>
    /// <param name="filePath">ファイルパス</param>
    /// <inheritdoc cref="Create(FilePath, ReadOnlySpan{byte})" path="/exception"/>
    void Delete(FilePath filePath);
}
