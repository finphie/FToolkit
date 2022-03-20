using System.Buffers;
using System.Text;

namespace FToolkit.Diagnostics;

/// <summary>
/// システムに関する操作の定義です。
/// </summary>
public interface ISystemOperations
{
    /// <summary>
    /// 指定されたURLを開きます。
    /// </summary>
    /// <param name="url">URL</param>
    void OpenInWebBrowser(string url);

    /// <summary>
    /// 指定されたコマンドを実行します。
    /// </summary>
    /// <param name="bufferWriter"><see cref="char"/>データを書き込むことができる出力シンク</param>
    /// <param name="command">コマンド</param>
    /// <param name="workingDirectory">ワーキングディレクトリ</param>
    /// <param name="environmentVariable">環境変数</param>
    /// <param name="encoding">エンコーディング</param>
    /// <param name="cancellationToken">キャンセル要求を行うためのトークン</param>
    /// <returns>
    /// このメソッドが完了すると、コマンドの実行が成功した場合に<see langword="true"/>を返します。
    /// 失敗した場合は<see langword="false"/>を返します。
    /// </returns>
    ValueTask<bool> TryStartCommandAsync(
        IBufferWriter<char> bufferWriter,
        string command,
        string? workingDirectory = null,
        IDictionary<string, string>? environmentVariable = null,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// 指定されたファイルを実行します。
    /// </summary>
    /// <param name="bufferWriter"><see cref="char"/>データを書き込むことができる出力シンク</param>
    /// <param name="fileName">ファイル名</param>
    /// <param name="arguments">引数</param>
    /// <param name="workingDirectory">ワーキングディレクトリ</param>
    /// <param name="environmentVariable">環境変数</param>
    /// <param name="encoding">エンコーディング</param>
    /// <param name="cancellationToken">キャンセル要求を行うためのトークン</param>
    /// <returns>
    /// このメソッドが完了すると、ファイルの実行が成功した場合に<see langword="true"/>を返します。
    /// 失敗した場合は<see langword="false"/>を返します。
    /// </returns>
    ValueTask<bool> TryStartProcessAsync(
        IBufferWriter<char> bufferWriter,
        string fileName,
        string? arguments = null,
        string? workingDirectory = null,
        IDictionary<string, string>? environmentVariable = null,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// 指定されたコマンドを実行します。
    /// </summary>
    /// <param name="command">コマンド</param>
    /// <param name="workingDirectory">ワーキングディレクトリ</param>
    /// <param name="environmentVariable">環境変数</param>
    /// <param name="encoding">エンコーディング</param>
    /// <param name="cancellationToken">キャンセル要求を行うためのトークン</param>
    /// <returns>
    /// このメソッドが完了すると、値は返されません。
    /// </returns>
    ValueTask TryWaitCommandAsync(
        string command,
        string? workingDirectory = null,
        IDictionary<string, string>? environmentVariable = null,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// 指定されたファイルを実行します。
    /// </summary>
    /// <param name="fileName">ファイル名</param>
    /// <param name="arguments">引数</param>
    /// <param name="workingDirectory">ワーキングディレクトリ</param>
    /// <param name="environmentVariable">環境変数</param>
    /// <param name="encoding">エンコーディング</param>
    /// <param name="cancellationToken">キャンセル要求を行うためのトークン</param>
    /// <returns>
    /// このメソッドが完了すると、値は返されません。
    /// </returns>
    ValueTask TryWaitProcessAsync(
        string fileName,
        string? arguments = null,
        string? workingDirectory = null,
        IDictionary<string, string>? environmentVariable = null,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default);
}
