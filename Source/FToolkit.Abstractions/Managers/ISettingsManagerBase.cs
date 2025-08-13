using FToolkit.Objects;
using FToolkit.Options;
using FToolkit.Publishers;

namespace FToolkit.Managers;

/// <summary>
/// 設定マネージャーの基本インターフェイスです。
/// </summary>
/// <typeparam name="TSettings">設定の型</typeparam>
public interface ISettingsManagerBase<out TSettings>
    where TSettings : ISettings
{
    /// <summary>
    /// 現在の設定値を取得します。
    /// </summary>
    TSettings Value { get; }

    /// <summary>
    /// すべての設定値を通知します。
    /// </summary>
    void NotifyAll();
}

/// <summary>
/// 自身のインスタンスを生成できる、設定マネージャーの基本インターフェイスです。
/// </summary>
/// <typeparam name="TSettings">設定の型</typeparam>
/// <typeparam name="TSelf">自身の型</typeparam>
public interface ISettingsManagerBase<TSettings, out TSelf> : ISettingsManagerBase<TSettings>, IConstructible<TSelf, IReloadableOptions<TSettings>, IPublisher>
    where TSettings : ISettings
    where TSelf : ISettingsManagerBase<TSettings, TSelf>;
