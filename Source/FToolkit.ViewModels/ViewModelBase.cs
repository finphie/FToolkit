using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using FToolkit.Managers;
using FToolkit.Objects;

namespace FToolkit.ViewModels;

/// <summary>
/// ViewModelの基底クラスです。
/// </summary>
public abstract class ViewModelBase : ObservableObject
{
    /// <summary>
    /// <see cref="ViewModelBase"/>クラスの新しいインスタンスを初期化します。
    /// </summary>
    protected ViewModelBase()
    {
        SettingsManager = Ioc.Default.GetRequiredService<ISettingsManagerBase<ApplicationSettingsBase>>();
        ApplicationInfo = Ioc.Default.GetRequiredService<ApplicationInfoBase>();
    }

    /// <summary>
    /// 設定マネージャーを取得します。
    /// </summary>
    protected virtual ISettingsManagerBase<ApplicationSettingsBase> SettingsManager { get; }

    /// <summary>
    /// アプリケーション情報を取得します。
    /// </summary>
    protected virtual ApplicationInfoBase ApplicationInfo { get; }
}
