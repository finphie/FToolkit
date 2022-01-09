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
    /// <param name="bufferWriter">バッファ</param>
    /// <param name="fileName">ファイル名</param>
    /// <param name="arguments">引数</param>
    /// <param name="environmentVariable">環境変数</param>
    /// <returns>
    /// ファイルの実行がに成功した場合は<see langword="true"/>、
    /// それ以外の場合は<see langword="false"/>。
    /// </returns>
    ValueTask<bool> TryStartProcessAsync(IBufferWriter<char> bufferWriter, string fileName, string? arguments = null, IDictionary<string, string>? environmentVariable = null);
}
