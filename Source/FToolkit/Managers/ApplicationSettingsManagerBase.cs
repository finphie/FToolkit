using CommunityToolkit.Diagnostics;
using FToolkit.Commands;
using FToolkit.Objects;
using FToolkit.Options;
using FToolkit.Publishers;
using FToolkit.ViewModels;

namespace FToolkit.Managers;

/// <summary>
/// アプリケーション設定マネージャーの基底クラスです。
/// </summary>
/// <typeparam name="TApplicationSettings">アプリケーション設定の型</typeparam>
public abstract class ApplicationSettingsManagerBase<TApplicationSettings> : SettingsManagerBase<TApplicationSettings>, IApplicationSettingsManagerBase<TApplicationSettings>
    where TApplicationSettings : ApplicationSettingsBase
{
    readonly IMainViewModel _mainViewModel;

    /// <summary>
    /// <see cref="ApplicationSettingsManagerBase{TApplicationSettings}"/>クラスの新しいインスタンスを初期化します。
    /// </summary>
    /// <param name="options">再読み込み可能なオプション値を取得するオブジェクト</param>
    /// <param name="publisher">イベントを送信するパブリッシャー</param>
    /// <param name="mainViewModel">メインViewModel</param>
    protected ApplicationSettingsManagerBase(IReloadableOptions<TApplicationSettings> options, IPublisher publisher, IMainViewModel mainViewModel)
        : base(options, publisher)
    {
        ArgumentNullException.ThrowIfNull(mainViewModel);
        _mainViewModel = mainViewModel;
    }

    /// <inheritdoc/>
    public override void NotifyAll()
    {
        Notify(Value.Theme);

        if (Value.Window is null)
        {
            return;
        }

        Notify(Value.Window.State);
    }

    /// <inheritdoc/>
    public void Notify(ApplicationTheme theme)
    {
        Publisher.Publish(theme);
        Notify(Value with { Theme = theme });
    }

    /// <inheritdoc/>
    public void Notify(WindowState windowState)
    {
        if (Value.Window is null)
        {
            ThrowHelper.ThrowInvalidOperationException("Window settings are not initialized.");
        }

        var message = new ChangeWindowStateCommand(_mainViewModel, windowState);
        Publisher.Publish(message);

        var newSettings = Value with { };
        newSettings.Window.State = windowState;
        Notify(newSettings);
    }
}
