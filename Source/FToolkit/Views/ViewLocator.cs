using FToolkit.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FToolkit.Views;

/// <summary>
/// 指定されたViewModelに関連付けられたViewを取得するクラスです。
/// </summary>
public sealed partial class ViewLocator : IViewLocator
{
    readonly ILogger<ViewLocator> _logger;
    readonly IServiceProvider _provider;

    /// <summary>
    /// <see cref="ViewLocator"/>クラスの新しいインスタンスを初期化します。
    /// </summary>
    /// <param name="logger">ログを記録するオブジェクト</param>
    /// <param name="provider">Viewの依存関係解決に使用するサービスプロバイダー</param>
    public ViewLocator(ILogger<ViewLocator> logger, IServiceProvider provider)
    {
        ArgumentNullException.ThrowIfNull(logger);
        ArgumentNullException.ThrowIfNull(provider);

        _logger = logger;
        _provider = provider;
    }

    /// <inheritdoc/>
    public IViewFor<T> GetView<T>()
        where T : class, IViewModel
    {
        LogViewGetting();
        return _provider.GetRequiredService<IViewFor<T>>();
    }

    [LoggerMessage(Level = LogLevel.Information, Message = "Getting the View.")]
    partial void LogViewGetting();
}
