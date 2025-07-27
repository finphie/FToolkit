using System.Diagnostics;
using System.Windows;
using FToolkit.Objects;
using FToolkit.ViewModels;

namespace FToolkit.Views.Wpf;

/// <summary>
/// WPF関連の拡張メソッドクラスです。
/// </summary>
static class WpfExtensions
{
    /// <summary>
    /// アプリケーションテーマをWPFテーマに変換します。
    /// </summary>
    /// <param name="theme">テーマ</param>
    /// <returns>WPFのテーマを返します。</returns>
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
    /// WPFテーマをアプリケーションテーマに変換します。
    /// </summary>
    /// <param name="theme">WPFテーマ</param>
    /// <returns>アプリケーションテーマを返します。</returns>
    public static ApplicationTheme ToApplicationTheme(this ThemeMode theme)
    {
        return (theme == ThemeMode.Light) ? ApplicationTheme.Light
            : (theme == ThemeMode.Dark) ? ApplicationTheme.Dark
            : (theme == ThemeMode.System) ? ApplicationTheme.System
            : throw new UnreachableException();
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
