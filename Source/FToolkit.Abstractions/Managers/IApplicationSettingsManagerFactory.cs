using FToolkit.Objects;
using FToolkit.ViewModels;

namespace FToolkit.Managers;

/// <summary>
/// 設定マネージャーを作成するファクトリーのインターフェイスです。
/// </summary>
/// <typeparam name="TSettings">設定の型</typeparam>
/// <typeparam name="TSettingsManager">設定マネージャーの型</typeparam>
public interface IApplicationSettingsManagerFactory<out TSettings, TSettingsManager>
    where TSettings : ApplicationSettingsBase
    where TSettingsManager : IApplicationSettingsManagerBase<TSettings, TSettingsManager>
{
    /// <summary>
    /// 設定マネージャーを作成します。
    /// </summary>
    /// <param name="viewModel">関連付けるViewModel</param>
    /// <returns>設定マネージャーを返します。</returns>
    TSettingsManager Create(IViewModel viewModel);
}
