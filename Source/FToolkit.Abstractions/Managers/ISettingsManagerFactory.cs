using FToolkit.Objects;
using FToolkit.Options;
using FToolkit.Publishers;

namespace FToolkit.Managers;

/// <summary>
/// 設定マネージャーを作成するファクトリーのインターフェイスです。
/// </summary>
/// <typeparam name="TSettings">設定の型</typeparam>
public interface ISettingsManagerFactory<TSettings>
    where TSettings : ISettings
{
    /// <summary>
    /// 設定マネージャーを作成します。
    /// </summary>
    /// <typeparam name="TSettingsManager">設定マネージャーの型</typeparam>
    /// <returns>設定マネージャーを返します。</returns>
    TSettingsManager Create<TSettingsManager>()
        where TSettingsManager : ISettingsManagerBase<TSettings>, IConstructible<TSettingsManager, IReloadableOptions<TSettings>, IPublisher>;

    /// <summary>
    /// 設定マネージャーを作成します。
    /// </summary>
    /// <typeparam name="TSettingsManager">設定マネージャーの型</typeparam>
    /// <typeparam name="TArgument">設定マネージャーに渡す引数の型</typeparam>
    /// <param name="argument">設定マネージャーに渡す引数</param>
    /// <returns>設定マネージャーを返します。</returns>
    TSettingsManager Create<TSettingsManager, TArgument>(TArgument argument)
        where TSettingsManager : ISettingsManagerBase<TSettings>, IConstructible<TSettingsManager, IReloadableOptions<TSettings>, IPublisher, TArgument>;
}
