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
    /// <param name="cancellationToken">キャンセル要求を行うためのトークン</param>
    /// <returns>このメソッドが完了すると、オブジェクトまたは値は返されません。</returns>
    /// <inheritdoc cref="File.Create(string)" path="/exception"/>
    ValueTask CreateAsync(FilePath filePath, ReadOnlyMemory<byte> bytes, CancellationToken cancellationToken = default);

    /// <summary>
    /// ファイルを新規作成します。
    /// </summary>
    /// <param name="filePath">ファイルパス</param>
    /// <param name="chars">データ</param>
    /// <param name="cancellationToken">キャンセル要求を行うためのトークン</param>
    /// <returns>このメソッドが完了すると、オブジェクトまたは値は返されません。</returns>
    /// <inheritdoc cref="CreateAsync(FilePath, ReadOnlyMemory{byte}, CancellationToken)" path="/exception"/>
    ValueTask CreateAsync(FilePath filePath, ReadOnlyMemory<char> chars, CancellationToken cancellationToken = default);

    /// <summary>
    /// ファイルに上書き保存します。
    /// </summary>
    /// <param name="filePath">ファイルパス</param>
    /// <param name="bytes">データ</param>
    /// <param name="cancellationToken">キャンセル要求を行うためのトークン</param>
    /// <returns>このメソッドが完了すると、オブジェクトまたは値は返されません。</returns>
    /// <inheritdoc cref="CreateAsync(FilePath, ReadOnlyMemory{byte}, CancellationToken)" path="/exception"/>
    ValueTask SaveAsync(FilePath filePath, ReadOnlyMemory<byte> bytes, CancellationToken cancellationToken = default);

    /// <summary>
    /// ファイルに上書き保存します。
    /// </summary>
    /// <param name="filePath">ファイルパス</param>
    /// <param name="chars">データ</param>
    /// <param name="cancellationToken">キャンセル要求を行うためのトークン</param>
    /// <returns>このメソッドが完了すると、オブジェクトまたは値は返されません。</returns>
    /// <inheritdoc cref="SaveAsync(FilePath, ReadOnlyMemory{byte}, CancellationToken)" path="/exception"/>
    ValueTask SaveAsync(FilePath filePath, ReadOnlyMemory<char> chars, CancellationToken cancellationToken = default);

    /// <summary>
    /// ファイルを削除します。
    /// </summary>
    /// <param name="filePath">ファイルパス</param>
    /// <inheritdoc cref="File.Delete(string)" path="/exception"/>
    void Delete(FilePath filePath);
}
