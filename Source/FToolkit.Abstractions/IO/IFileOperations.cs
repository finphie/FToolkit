namespace FToolkit.IO;

/// <summary>
/// ファイル操作に関する定義です。
/// </summary>
public interface IFileOperations
{
    /// <summary>
    /// 指定されたデータをファイルに保存します。
    /// </summary>
    /// <param name="filePath">ファイルパス</param>
    /// <param name="bytes">データ</param>
    void Create(string filePath, ReadOnlySpan<byte> bytes);

    /// <summary>
    /// 指定されたデータをファイルに保存します。
    /// </summary>
    /// <param name="filePath">ファイルパス</param>
    /// <param name="bytes">データ</param>
    void Create(string filePath, ReadOnlyMemory<byte> bytes);

    /// <summary>
    /// 指定されたデータをファイルに保存します。
    /// </summary>
    /// <param name="filePath">ファイルパス</param>
    /// <param name="bytes">データ</param>
    void Save(string filePath, ReadOnlySpan<byte> bytes);

    /// <summary>
    /// 指定されたデータをファイルに保存します。
    /// </summary>
    /// <param name="filePath">ファイルパス</param>
    /// <param name="bytes">データ</param>
    void Save(string filePath, ReadOnlyMemory<byte> bytes);

    /// <summary>
    /// 指定されたファイルを削除します。
    /// </summary>
    /// <param name="filePath">ファイルパス</param>
    void Delete(string filePath);
}
