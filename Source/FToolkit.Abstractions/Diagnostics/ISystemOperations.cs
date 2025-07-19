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
    /// <exception cref="ArgumentException"><paramref name="url"/>が空です。</exception>
    void OpenInWebBrowser(string url);

    /// <summary>
    /// 指定されたURLを開きます。
    /// </summary>
    /// <param name="url">URL</param>
    /// <exception cref="ArgumentNullException"><paramref name="url"/>がnullです。</exception>
    void OpenInWebBrowser(Uri url);
}
