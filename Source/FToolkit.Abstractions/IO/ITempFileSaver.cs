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
    /// <param name="outputFilePath">出力先ファイルパス</param>
    /// <param name="cancellationToken">キャンセル要求を行うためのトークン</param>
    /// <returns>このメソッドが完了すると、オブジェクトまたは値は返されません。</returns>
    ValueTask ExecuteAsync(DirectoryName parentDirectoryName, FileName fileName, ReadOnlyMemory<byte> bytes, out FilePath outputFilePath, CancellationToken cancellationToken = default);

    /// <summary>
    /// 指定されたディレクトリ内にファイルをUTF-8文字列として保存します。
    /// </summary>
    /// <param name="parentDirectoryName">ファイルを保存するディレクトリ名</param>
    /// <param name="fileName">ファイル名</param>
    /// <param name="chars">書き込む文字列</param>
    /// <param name="outputFilePath">出力先ファイルパス</param>
    /// <param name="cancellationToken">キャンセル要求を行うためのトークン</param>
    /// <returns>このメソッドが完了すると、オブジェクトまたは値は返されません。</returns>
    ValueTask ExecuteAsync(DirectoryName parentDirectoryName, FileName fileName, ReadOnlyMemory<char> chars, out FilePath outputFilePath, CancellationToken cancellationToken = default);
}
