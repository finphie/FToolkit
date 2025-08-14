using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using FToolkit.Managers;
using FToolkit.Objects;

namespace FToolkit.ViewModels;

/// <summary>
/// ViewModelの基底クラスです。
/// </summary>
public abstract class ViewModelBase : ObservableObject, IViewModel
{
    /// <summary>
    /// <see cref="ViewModelBase"/>クラスの新しいインスタンスを初期化します。
    /// </summary>
    protected ViewModelBase()
    {
        ApplicationInfo = Ioc.Default.GetRequiredService<ApplicationInfoBase>();
        SettingsManager = Ioc.Default.GetRequiredService<IApplicationSettingsManagerBase<ApplicationSettingsBase>>();
    }

    /// <summary>
    /// アプリケーション情報を取得します。
    /// </summary>
    protected virtual ApplicationInfoBase ApplicationInfo { get; }

    /// <summary>
    /// 設定マネージャーを取得します。
    /// </summary>
    protected virtual IApplicationSettingsManagerBase<ApplicationSettingsBase> SettingsManager { get; }

    /// <summary>
    /// 初期化処理を行います。
    /// </summary>
    protected virtual void Initialize()
    {
    }
}
