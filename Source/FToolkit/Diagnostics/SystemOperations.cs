using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Logging;

namespace FToolkit.Diagnostics;

/// <summary>
/// システムに関する操作を行うクラスです。
/// </summary>
public sealed partial class SystemOperations : ISystemOperations
{
    readonly ILogger<SystemOperations> _logger;

    /// <summary>
    /// <see cref="SystemOperations"/>クラスの新しいインスタンスを初期化します。
    /// </summary>
    /// <param name="logger">ログを記録するオブジェクト</param>
    /// <exception cref="ArgumentNullException"><paramref name="logger"/>がnullです。</exception>
    public SystemOperations(ILogger<SystemOperations> logger)
    {
        ArgumentNullException.ThrowIfNull(logger);
        _logger = logger;
    }

    /// <inheritdoc/>
    [SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP004:Don't ignore created IDisposable", Justification = "URL")]
    public void OpenInWebBrowser(string url)
    {
        ArgumentException.ThrowIfNullOrEmpty(url);

        LogOpeningLink(url);

        Process.Start(new ProcessStartInfo
        {
            FileName = url,
            UseShellExecute = true
        });
    }

    /// <inheritdoc/>
    public void OpenInWebBrowser(Uri url)
    {
        ArgumentNullException.ThrowIfNull(url);
        OpenInWebBrowser(url.AbsolutePath);
    }

    [LoggerMessage(Level = LogLevel.Information, Message = "Opening link: {url}")]
    partial void LogOpeningLink(string url);
}
