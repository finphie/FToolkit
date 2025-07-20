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
    void Execute(DirectoryName parentDirectoryName, FileName fileName, ReadOnlySpan<byte> bytes);

    /// <summary>
    /// 指定されたディレクトリ内にファイルをUTF-8文字列として保存します。
    /// </summary>
    /// <param name="parentDirectoryName">ファイルを保存するディレクトリ名</param>
    /// <param name="fileName">ファイル名</param>
    /// <param name="chars">書き込む文字列</param>
    void Execute(DirectoryName parentDirectoryName, FileName fileName, ReadOnlySpan<char> chars);
}
