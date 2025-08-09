using CommunityToolkit.Mvvm.ComponentModel;
using FToolkit.Managers;
using FToolkit.Objects;

namespace FToolkit.ViewModels;

/// <summary>
/// メインViewのViewModel基底クラスです。
/// </summary>
public abstract class MainViewModelBase : ObservableObject, IMainViewModel
{
    readonly ISettingsManagerBase<ApplicationSettingsBase> _settingsManager;

    /// <summary>
    /// <see cref="MainViewModelBase"/>クラスの新しいインスタンスを初期化します。
    /// </summary>
    /// <param name="settingsManager">設定マネージャーのオブジェクト</param>
    /// <param name="applicationInfo">アプリケーション情報のオブジェクト</param>
    protected MainViewModelBase(ISettingsManagerBase<ApplicationSettingsBase> settingsManager, ApplicationInfoBase applicationInfo)
    {
        ArgumentNullException.ThrowIfNull(settingsManager);
        ArgumentNullException.ThrowIfNull(applicationInfo);

        _settingsManager = settingsManager;

        ApplicationTitle = applicationInfo.Title;
        ApplicationAuthor = applicationInfo.Author;
    }

    /// <summary>
    /// アプリケーションタイトル
    /// </summary>
    public string ApplicationTitle { get; }

    /// <summary>
    /// 作者名
    /// </summary>
    public string ApplicationAuthor { get; }

    /// <summary>
    /// 初期化処理を行います。
    /// </summary>
    protected virtual void Initialize()
        => _settingsManager.NotifyAll();
}
