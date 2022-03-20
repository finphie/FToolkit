using System.Buffers;

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
    /// 指定されたファイルを実行します。
    /// </summary>
    /// <param name="bufferWriter">バッファーライター</param>
    /// <param name="fileName">ファイル名</param>
    /// <param name="arguments">引数</param>
    /// <param name="environmentVariable">環境変数</param>
    /// <returns>
    /// このメソッドが完了すると、ファイルの実行が成功した場合に<see langword="true"/>を返します。
    /// 失敗した場合は<see langword="false"/>を返します。
    /// </returns>
    ValueTask<bool> TryStartProcessAsync(IBufferWriter<char> bufferWriter, string fileName, string? arguments = null, IDictionary<string, string>? environmentVariable = null);
}
