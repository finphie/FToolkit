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
    /// <exception cref="ArgumentNullException"><paramref name="url"/>がnullです。</exception>
    void OpenInWebBrowser(string url);

    /// <summary>
    /// 指定されたURLを開きます。
    /// </summary>
    /// <param name="url">URL</param>
    /// <exception cref="ArgumentNullException"><paramref name="url"/>がnullです。</exception>
    void OpenInWebBrowser(Uri url);

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
    /// このメソッドが完了すると、コマンドの実行が成功した場合に0を返します。
    /// 失敗した場合は0以外の終了コードを返します。
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="bufferWriter"/>または<paramref name="command"/>がnullです。</exception>
    /// <exception cref="InvalidOperationException">コマンドを実行できません。</exception>
    ValueTask<int> WaitCommandAsync(
        IBufferWriter<char> bufferWriter,
        string command,
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
    /// <inheritdoc cref="WaitCommandAsync(IBufferWriter{char}, string, string?, IDictionary{string, string}?, Encoding?, CancellationToken)" path="/returns"/>
    /// <exception cref="ArgumentNullException"><paramref name="command"/>がnullです。</exception>
    /// <exception cref="InvalidOperationException">コマンドを実行できません。</exception>
    ValueTask<int> WaitCommandAsync(
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
    /// このメソッドが完了すると、プロセスの実行が成功した場合に0を返します。
    /// 失敗した場合は0以外の終了コードを返します。
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="bufferWriter"/>または<paramref name="fileName"/>がnullです。</exception>
    /// <exception cref="InvalidOperationException">ファイルを実行できません。</exception>
    ValueTask<int> WaitProcessAsync(
        IBufferWriter<char> bufferWriter,
        string fileName,
        string? arguments = null,
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
    /// <inheritdoc cref="WaitProcessAsync(IBufferWriter{char}, string, string?, string?, IDictionary{string, string}?, Encoding?, CancellationToken)" path="/returns"/>
    /// <exception cref="ArgumentNullException"><paramref name="fileName"/>がnullです。</exception>
    /// <exception cref="InvalidOperationException">ファイルを実行できません。</exception>
    ValueTask<int> WaitProcessAsync(
        string fileName,
        string? arguments = null,
        string? workingDirectory = null,
        IDictionary<string, string>? environmentVariable = null,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default);
}
