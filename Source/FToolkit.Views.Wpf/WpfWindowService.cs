using System.Windows;
using FToolkit.Objects;
using FToolkit.ViewModels;
using FToolkit.Views.Wpf.Extensions;
using Microsoft.Extensions.Logging;
using R3;
using WindowState = FToolkit.Objects.WindowState;

namespace FToolkit.Views.Wpf;

/// <summary>
/// ViewModelに関連付けられたWindow関連操作を行うクラスです。
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
    /// <exception cref="ArgumentNullException"><paramref name="logger"/>、<paramref name="viewLocator"/>が<see langword="null"/>です。</exception>
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
        ArgumentNullException.ThrowIfNull(ownerViewModel);

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
        ArgumentNullException.ThrowIfNull(ownerViewModel);

        LogShowDialogWindow();

        var ownerWindow = Application.Current.Windows.FindWindowByViewModel(ownerViewModel);
        var window = GetWindow<TViewModel>();

        window.Owner = ownerWindow;
        window.ShowDialog();
    }

    /// <inheritdoc/>
    public void ChangeWindowState<TViewModel>(TViewModel viewModel, WindowState windowState)
        where TViewModel : class, IViewModel
    {
        ArgumentNullException.ThrowIfNull(viewModel);

        LogChangeWindowState(windowState);

        Application.Current.Dispatcher.Invoke(() =>
        {
            var window = Application.Current.Windows.FindWindowByViewModel(viewModel);
            window.WindowState = windowState.ToWpfWindowState();
        });
    }

    /// <inheritdoc/>
    public Observable<WindowState> ObserveWindowStateChanged<TViewModel>(TViewModel viewModel)
        where TViewModel : class, IViewModel
    {
        ArgumentNullException.ThrowIfNull(viewModel);

        var window = Application.Current.Windows.FindWindowByViewModel(viewModel);
        return window.WindowStateChangedAsObservable()
            .Select(static x => x.ToWindowState());
    }

    /// <inheritdoc/>
    public void ChangeWindowSize<TViewModel>(TViewModel viewModel, WindowSize windowSize)
        where TViewModel : class, IViewModel
    {
        ArgumentNullException.ThrowIfNull(viewModel);
        ArgumentNullException.ThrowIfNull(windowSize);

        LogChangeWindowSize(windowSize);

        Application.Current.Dispatcher.Invoke(() =>
        {
            var window = Application.Current.Windows.FindWindowByViewModel(viewModel);
            window.Width = windowSize.Width;
            window.Height = windowSize.Height;
        });
    }

    /// <inheritdoc/>
    public Observable<WindowSize> ObserveWindowSizeChanged<TViewModel>(TViewModel viewModel)
        where TViewModel : class, IViewModel
    {
        ArgumentNullException.ThrowIfNull(viewModel);

        var window = Application.Current.Windows.FindWindowByViewModel(viewModel);
        return window.WindowSizeChangedAsObservable()
            .Select(static x => new WindowSize((int)x.NewSize.Width, (int)x.NewSize.Height));
    }

    Window GetWindow<T>()
        where T : class, IViewModel
    {
        var view = _viewLocator.GetView<T>();

        if (view is not Window window)
        {
            throw new InvalidOperationException($"Could not retrieve a Window for ViewModel '{typeof(T).Name}'.");
        }

        // ViewModelはDIコンテナによって管理されているが、明示的に破棄する必要がある
        window.Unloaded += static (sender, _) =>
        {
            var view = (IViewFor<T>)sender;
            (view.ViewModel as IDisposable)?.Dispose();
        };

        return window;
    }

    [LoggerMessage(Level = LogLevel.Debug, Message = "Window will be shown.")]
    partial void LogShowWindow();

    [LoggerMessage(Level = LogLevel.Debug, Message = "Dialog Window will be shown.")]
    partial void LogShowDialogWindow();

    [LoggerMessage(Level = LogLevel.Debug, Message = "Window state will be changed to {windowState}.")]
    partial void LogChangeWindowState(WindowState windowState);

    [LoggerMessage(Level = LogLevel.Debug, Message = "Window size will be changed to {windowSize}.")]
    partial void LogChangeWindowSize(WindowSize windowSize);
}
