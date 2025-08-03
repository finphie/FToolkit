using FToolkit.Objects;

namespace FToolkit.IO;

/// <summary>
/// 指定された内容で一時ファイルを保存する処理に関する定義です。
/// </summary>
public interface ITempFileSaver
{
    /// <summary>
    /// 指定されたディレクトリ内にファイルを保存します。
    /// </summary>
    /// <param name="parentDirectoryName">ファイルを保存するディレクトリ名</param>
    /// <param name="fileName">ファイル名</param>
    /// <param name="bytes">書き込むバイト列</param>
    /// <param name="cancellationToken">キャンセル要求を行うためのトークン</param>
    /// <returns>出力先ファイルパスを返します。</returns>
    ValueTask<FilePath> ExecuteAsync(DirectoryName parentDirectoryName, FileName fileName, ReadOnlyMemory<byte> bytes, CancellationToken cancellationToken = default);

    /// <summary>
    /// 指定されたディレクトリ内にファイルをUTF-8文字列として保存します。
    /// </summary>
    /// <param name="parentDirectoryName">ファイルを保存するディレクトリ名</param>
    /// <param name="fileName">ファイル名</param>
    /// <param name="chars">書き込む文字列</param>
    /// <param name="cancellationToken">キャンセル要求を行うためのトークン</param>
    /// <returns>出力先ファイルパスを返します。</returns>
    ValueTask<FilePath> ExecuteAsync(DirectoryName parentDirectoryName, FileName fileName, ReadOnlyMemory<char> chars, CancellationToken cancellationToken = default);
}
