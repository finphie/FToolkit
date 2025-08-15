using System.Windows;
using R3;

namespace FToolkit.Views.Wpf;

/// <summary>
/// WPFのイベントを<see cref="Observable{T}"/>へ変換する拡張メソッドです。
/// </summary>
static class WpfEventToObservableExtensions
{
    /// <summary>
    /// <see cref="Window.StateChanged"/>イベントを監視し、<see cref="WindowState"/>の変更を<see cref="Observable{T}"/>として取得します。
    /// </summary>
    /// <param name="window">監視対象の<see cref="Window"/>オブジェクト</param>
    /// <returns><see cref="WindowState"/>の変更を通知する<see cref="Observable{T}"/></returns>
    public static Observable<WindowState> WindowStateChangedAsObservable(this Window window)
    {
        return Observable.FromEventHandler(
            handler => window.StateChanged += handler,
            handler => window.StateChanged -= handler)
            .Select(x => window.WindowState);
    }
}
