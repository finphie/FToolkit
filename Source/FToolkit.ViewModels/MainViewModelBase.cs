using CommunityToolkit.Mvvm.ComponentModel;
using FToolkit.Managers;
using FToolkit.Objects;

namespace FToolkit.ViewModels;

/// <summary>
/// メインViewのViewModel基底クラスです。
/// </summary>
public abstract class MainViewModelBase : ObservableObject, IViewModel
{
    readonly ISettingsManagerBase<ApplicationSettingsBase> _settingsManager;

    /// <summary>
    /// <see cref="MainViewModelBase"/>クラスの新しいインスタンスを初期化します。
    /// </summary>
    /// <param name="settingsManager">設定マネージャーのオブジェクト</param>
    protected MainViewModelBase(ISettingsManagerBase<ApplicationSettingsBase> settingsManager)
    {
        ArgumentNullException.ThrowIfNull(settingsManager);
        _settingsManager = settingsManager;
    }

    /// <summary>
    /// 初期化処理を行います。
    /// </summary>
    protected virtual void Initialize()
        => _settingsManager.NotifyAll();
}
