using FToolkit.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FToolkit.Views;

/// <summary>
/// 指定されたViewModel型に関連付けられたViewを取得するクラスです。
/// </summary>
public sealed partial class ViewLocator : IViewLocator
{
    readonly ILogger<ViewLocator> _logger;
    readonly IServiceProvider _services;

    /// <summary>
    /// <see cref="ViewLocator"/>クラスの新しいインスタンスを初期化します。
    /// </summary>
    /// <param name="logger">ロガー</param>
    /// <param name="services">Viewの依存関係解決に使用するサービスプロバイダー</param>
    public ViewLocator(ILogger<ViewLocator> logger, IServiceProvider services)
    {
        ArgumentNullException.ThrowIfNull(logger);
        ArgumentNullException.ThrowIfNull(services);

        _logger = logger;
        _services = services;
    }

    /// <inheritdoc/>
    public IViewFor<T> GetView<T>()
        where T : class, IViewModel
    {
        LogViewGetting();
        return _services.GetRequiredService<IViewFor<T>>();
    }

    [LoggerMessage(Level = LogLevel.Information, Message = "Getting the View.")]
    partial void LogViewGetting();
}
