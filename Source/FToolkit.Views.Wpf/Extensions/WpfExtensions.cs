using System.Diagnostics;
using System.Windows;
using FToolkit.Objects;
using FToolkit.ViewModels;
using WindowState = FToolkit.Objects.WindowState;
using WpfWindowState = System.Windows.WindowState;

namespace FToolkit.Views.Wpf.Extensions;

/// <summary>
/// WPF関連の拡張メソッドクラスです。
/// </summary>
static class WpfExtensions
{
    /// <summary>
    /// アプリケーションテーマを<see cref="ThemeMode"/>に変換します。
    /// </summary>
    /// <param name="theme">アプリケーションテーマ</param>
    /// <returns>アプリケーションテーマを、対応する<see cref="ThemeMode"/>の値で返します。</returns>
#pragma warning disable WPF0001 // 種類は、評価の目的でのみ提供されています。将来の更新で変更または削除されることがあります。続行するには、この診断を非表示にします。
    public static ThemeMode ToWpfApplicationTheme(this ApplicationTheme theme)
    {
        return theme switch
        {
            ApplicationTheme.Light => ThemeMode.Light,
            ApplicationTheme.Dark => ThemeMode.Dark,
            ApplicationTheme.System => ThemeMode.System,
            _ => throw new UnreachableException()
        };
    }

    /// <summary>
    /// <see cref="ThemeMode"/>をアプリケーションテーマに変換します。
    /// </summary>
    /// <param name="theme"><see cref="ThemeMode"/>の値</param>
    /// <returns><see cref="ThemeMode"/>の値を、対応するアプリケーションテーマで返します。</returns>
    public static ApplicationTheme ToApplicationTheme(this ThemeMode theme)
    {
        return theme == ThemeMode.Light ? ApplicationTheme.Light
            : theme == ThemeMode.Dark ? ApplicationTheme.Dark
            : theme == ThemeMode.System ? ApplicationTheme.System
            : throw new UnreachableException();
    }

    /// <summary>
    /// Windowの状態を<see cref="WpfWindowState"/>に変換します。
    /// </summary>
    /// <param name="windowState">Windowの状態</param>
    /// <returns>Windowの状態を、対応する<see cref="WpfWindowState"/>の値で返します。</returns>
    public static WpfWindowState ToWpfWindowState(this WindowState windowState)
    {
        return windowState switch
        {
            WindowState.Normal => WpfWindowState.Normal,
            WindowState.Maximized => WpfWindowState.Maximized,
            WindowState.Minimized => WpfWindowState.Minimized,
            _ => throw new UnreachableException()
        };
    }

    /// <summary>
    /// <see cref="WpfWindowState"/>をWindowの状態に変換します。
    /// </summary>
    /// <param name="windowState"><see cref="WpfWindowState"/>の値</param>
    /// <returns><see cref="WpfWindowState"/>の値を、対応するWindowの状態に変換します。</returns>
    public static WindowState ToWindowState(this WpfWindowState windowState)
    {
        return windowState switch
        {
            WpfWindowState.Normal => WindowState.Normal,
            WpfWindowState.Maximized => WindowState.Maximized,
            WpfWindowState.Minimized => WindowState.Minimized,
            _ => throw new UnreachableException()
        };
    }

    /// <summary>
    /// 指定したViewModelに対応するWindowを検索して返します。
    /// </summary>
    /// <typeparam name="T">ViewModelの型</typeparam>
    /// <param name="windows">Windowのコレクション</param>
    /// <param name="viewModel">検索対象のViewModel</param>
    /// <returns>対応するWindowを返します。</returns>
    public static Window FindWindowByViewModel<T>(this WindowCollection windows, T viewModel)
        where T : class, IViewModel
    {
        return (Window)windows.OfType<IViewFor<T>>()
            .Single(x => ReferenceEqualityComparer.Instance.Equals(x.ViewModel, viewModel));
    }
}
