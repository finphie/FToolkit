using System.Windows;
using R3;

namespace FToolkit.Views.Wpf.Extensions;

/// <summary>
/// WPFのイベントを<see cref="Observable{T}"/>へ変換する拡張メソッドです。
/// </summary>
static class WpfEventToObservableExtensions
{
    /// <summary>
    /// <see cref="Window.StateChanged"/>イベントを監視し、<see cref="WindowState"/>の変更を<see cref="Observable{T}"/>として取得します。
    /// </summary>
    /// <param name="window">監視対象の<see cref="Window"/>オブジェクト</param>
    /// <returns><see cref="WindowState"/>の変更を通知する<see cref="Observable{T}"/>を返します。</returns>
    public static Observable<WindowState> WindowStateChangedAsObservable(this Window window)
    {
        return Observable.FromEventHandler(
            handler => window.StateChanged += handler,
            handler => window.StateChanged -= handler)
            .Select(_ => window.WindowState);
    }

    /// <summary>
    /// <see cref="FrameworkElement.SizeChanged"/>イベントを監視し、Windowサイズの変更を<see cref="Observable{T}"/>として取得します。
    /// </summary>
    /// <param name="window">監視対象の<see cref="Window"/>オブジェクト</param>
    /// <returns>Windowサイズの変更を通知する<see cref="Observable{T}"/>を返します。</returns>
    public static Observable<SizeChangedEventArgs> WindowSizeChangedAsObservable(this Window window)
    {
        return Observable.FromEvent<SizeChangedEventHandler, SizeChangedEventArgs>(
            static handler => (sender, e) => handler(e),
            handler => window.SizeChanged += handler,
            handler => window.SizeChanged -= handler);
    }
}
