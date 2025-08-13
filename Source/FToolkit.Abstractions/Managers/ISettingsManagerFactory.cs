using FToolkit.Objects;

namespace FToolkit.Managers;

/// <summary>
/// 設定マネージャーを作成するファクトリーのインターフェイスです。
/// </summary>
/// <typeparam name="TSettings">設定の型</typeparam>
/// <typeparam name="TSettingsManager">設定マネージャーの型</typeparam>
public interface ISettingsManagerFactory<out TSettings, TSettingsManager>
    where TSettings : ISettings
    where TSettingsManager : ISettingsManagerBase<TSettings, TSettingsManager>
{
    /// <summary>
    /// 設定マネージャーを作成します。
    /// </summary>
    /// <returns>設定マネージャーを返します。</returns>
    TSettingsManager Create();
}
