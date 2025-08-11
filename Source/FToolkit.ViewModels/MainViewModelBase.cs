namespace FToolkit.ViewModels;

/// <summary>
/// メインViewのViewModel基底クラスです。
/// </summary>
public abstract class MainViewModelBase : ViewModelBase, IMainViewModel
{
    /// <summary>
    /// <see cref="MainViewModelBase"/>クラスの新しいインスタンスを初期化します。
    /// </summary>
    protected MainViewModelBase()
    {
        ApplicationTitle = ApplicationInfo.Title;
        ApplicationAuthor = ApplicationInfo.Author;
    }

    /// <summary>
    /// アプリケーションタイトル
    /// </summary>
    public required string ApplicationTitle { get; init; }

    /// <summary>
    /// 作者名
    /// </summary>
    public required string ApplicationAuthor { get; init; }

    /// <inheritdoc/>
    protected override void Initialize()
    {
        base.Initialize();
        SettingsManager.NotifyAll();
    }
}
