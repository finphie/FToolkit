using System.Windows;
using FToolkit.ViewModels;
using Microsoft.Extensions.Logging;

namespace FToolkit.Views.Wpf;

/// <summary>
/// ViewModelに関連付けられたWindowを表示するクラスです。
/// </summary>
public sealed partial class WpfWindowService : IWindowService
{
    readonly ILogger<WpfWindowService> _logger;
    readonly IViewLocator _viewLocator;

    /// <summary>
    /// <see cref="WpfWindowService"/>クラスの新しいインスタンスを初期化します。
    /// </summary>
    /// <param name="logger">ログを記録するオブジェクト</param>
    /// <param name="viewLocator">ViewModelに対応するViewを取得するオブジェクト</param>
    public WpfWindowService(ILogger<WpfWindowService> logger, IViewLocator viewLocator)
    {
        ArgumentNullException.ThrowIfNull(logger);
        ArgumentNullException.ThrowIfNull(viewLocator);

        _logger = logger;
        _viewLocator = viewLocator;
    }

    /// <inheritdoc/>
    public void Show<TViewModel>()
        where TViewModel : class, IViewModel
    {
        LogShowWindow();

        var window = GetWindow<TViewModel>();
        window.Show();
    }

    /// <inheritdoc/>
    public void Show<TOwnerViewModel, TViewModel>(TOwnerViewModel ownerViewModel)
        where TOwnerViewModel : class, IViewModel
        where TViewModel : class, IViewModel
    {
        LogShowWindow();

        var ownerWindow = Application.Current.Windows.FindWindowByViewModel(ownerViewModel);
        var window = GetWindow<TViewModel>();

        window.Owner = ownerWindow;
        window.Show();
    }

    /// <inheritdoc/>
    public void ShowDialog<TViewModel>()
        where TViewModel : class, IViewModel
    {
        LogShowDialogWindow();

        var window = GetWindow<TViewModel>();
        window.ShowDialog();
    }

    /// <inheritdoc/>
    public void ShowDialog<TOwnerViewModel, TViewModel>(TOwnerViewModel ownerViewModel)
        where TOwnerViewModel : class, IViewModel
        where TViewModel : class, IViewModel
    {
        LogShowDialogWindow();

        var ownerWindow = Application.Current.Windows.FindWindowByViewModel(ownerViewModel);
        var window = GetWindow<TViewModel>();

        window.Owner = ownerWindow;
        window.ShowDialog();
    }

    Window GetWindow<T>()
        where T : class, IViewModel
    {
        var view = _viewLocator.GetView<T>();

        return view is Window window
            ? window
            : throw new InvalidOperationException($"Could not retrieve a Window for ViewModel '{typeof(T).Name}'.");
    }

    [LoggerMessage(Level = LogLevel.Information, Message = "Window will be shown.")]
    partial void LogShowWindow();

    [LoggerMessage(Level = LogLevel.Information, Message = "Dialog Window will be shown.")]
    partial void LogShowDialogWindow();
}
