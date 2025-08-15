using FToolkit.Commands;
using R3;

namespace FToolkit.ViewModels;

/// <summary>
/// メインViewのViewModel基底クラスです。
/// </summary>
public abstract class MainViewModelBase : ViewModelBase, IMainViewModel, IDisposable
{
    DisposableBag _disposable;
    bool _disposedValue;

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
    public string ApplicationTitle { get; init; }

    /// <summary>
    /// 作者名
    /// </summary>
    public string ApplicationAuthor { get; init; }

    /// <inheritdoc/>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// リソースを解放します。
    /// </summary>
    /// <param name="disposing"><see langword="true"/>の場合はマネージドリソースを解放します。 </param>
    protected virtual void Dispose(bool disposing)
    {
        if (_disposedValue)
        {
            return;
        }

        if (disposing)
        {
            _disposable.Dispose();
        }

        _disposedValue = true;
    }

    /// <inheritdoc/>
    protected override void Initialize()
    {
        base.Initialize();
        SettingsManager.NotifyAll(new(this));

        WindowService.ObserveWindowStateChanged(this)
            .Subscribe(x => SettingsManager.Notify(new ChangeWindowStateCommand(this, x)))
            .AddTo(ref _disposable);
    }
}
