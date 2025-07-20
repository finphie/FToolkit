using System.Security;
using FToolkit.Objects;

namespace FToolkit.IO;

/// <summary>
/// ファイル操作に関する定義です。
/// </summary>
public interface IFileOperations
{
    /// <summary>
    /// ファイルを新規作成します。
    /// </summary>
    /// <param name="filePath">ファイルパス</param>
    /// <param name="bytes">データ</param>
    /// <exception cref="ArgumentNullException"><paramref name="filePath"/>がnullです。</exception>
    /// <exception cref="ArgumentException"><paramref name="filePath"/>が空文字か空白です。</exception>
    /// <exception cref="NotSupportedException"><paramref name="filePath"/>がファイル以外のデバイスを参照しています。</exception>
    /// <exception cref="IOException">I/Oエラーが発生しました。</exception>
    /// <exception cref="SecurityException">アクセス許可がありません。</exception>
    /// <exception cref="DirectoryNotFoundException"><paramref name="filePath"/>が無効です。</exception>
    /// <exception cref="UnauthorizedAccessException">オペレーティングシステムによってアクセスが拒否されました。</exception>
    /// <exception cref="PathTooLongException"><paramref name="filePath"/>がシステム定義の最大長を超えています。</exception>
    void Create(string filePath, ReadOnlySpan<byte> bytes);

    /// <summary>
    /// ファイルを新規作成します。
    /// </summary>
    /// <param name="filePath">ファイルパス</param>
    /// <param name="chars">データ</param>
    /// <inheritdoc cref="Create(string, ReadOnlySpan{byte})" path="/exception"/>
    void Create(string filePath, ReadOnlySpan<char> chars);

    /// <inheritdoc cref="Create(string, ReadOnlySpan{byte})"/>
    void Create(FilePath filePath, ReadOnlySpan<byte> bytes);

    /// <inheritdoc cref="Create(string, ReadOnlySpan{char})"/>
    void Create(FilePath filePath, ReadOnlySpan<char> chars);

    /// <summary>
    /// ファイルに上書き保存します。
    /// </summary>
    /// <param name="filePath">ファイルパス</param>
    /// <param name="bytes">データ</param>
    /// <inheritdoc cref="Create(string, ReadOnlySpan{byte})" path="/exception"/>
    void Save(string filePath, ReadOnlySpan<byte> bytes);

    /// <summary>
    /// ファイルに上書き保存します。
    /// </summary>
    /// <param name="filePath">ファイルパス</param>
    /// <param name="chars">データ</param>
    /// <inheritdoc cref="Save(string, ReadOnlySpan{byte})" path="/exception"/>
    void Save(string filePath, ReadOnlySpan<char> chars);

    /// <inheritdoc cref="Save(string, ReadOnlySpan{byte})"/>
    void Save(FilePath filePath, ReadOnlySpan<byte> bytes);

    /// <inheritdoc cref="Save(string, ReadOnlySpan{char})"/>
    void Save(FilePath filePath, ReadOnlySpan<char> chars);

    /// <summary>
    /// ファイルを削除します。
    /// </summary>
    /// <param name="filePath">ファイルパス</param>
    /// <inheritdoc cref="Create(string, ReadOnlySpan{byte})" path="/exception"/>
    void Delete(string filePath);

    /// <inheritdoc cref="Delete(string)"/>
    void Delete(FilePath filePath);
}
