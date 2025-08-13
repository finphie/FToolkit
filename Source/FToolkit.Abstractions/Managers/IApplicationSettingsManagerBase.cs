using FToolkit.Objects;
using FToolkit.Options;
using FToolkit.Publishers;
using FToolkit.ViewModels;

namespace FToolkit.Managers;

/// <summary>
/// アプリケーション設定マネージャーの基本インターフェイスです。
/// </summary>
/// <typeparam name="TSettings">設定の型</typeparam>
public interface IApplicationSettingsManagerBase<out TSettings> : ISettingsManagerBase<TSettings>
    where TSettings : ApplicationSettingsBase
{
    /// <summary>
    /// アプリケーションテーマの変更を通知します。
    /// </summary>
    /// <param name="theme">アプリケーションテーマ</param>
    void Notify(ApplicationTheme theme);

    /// <summary>
    /// Windowの状態変更を通知します。
    /// </summary>
    /// <param name="windowState">Windowの状態</param>
    void Notify(WindowState windowState);
}

/// <summary>
/// 自身のインスタンスを生成できる、アプリケーション設定マネージャーの基本インターフェイスです。
/// </summary>
/// <typeparam name="TSettings">設定の型</typeparam>
/// <typeparam name="TSelf">自身の型</typeparam>
public interface IApplicationSettingsManagerBase<TSettings, out TSelf> : IApplicationSettingsManagerBase<TSettings>, IConstructible<TSelf, IReloadableOptions<TSettings>, IPublisher, IViewModel>
    where TSettings : ApplicationSettingsBase
    where TSelf : IApplicationSettingsManagerBase<TSettings, TSelf>;
