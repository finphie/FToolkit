using CommunityToolkit.Diagnostics;
using FToolkit.Commands;
using FToolkit.Objects;
using FToolkit.Options;
using FToolkit.Publishers;

namespace FToolkit.Managers;

/// <summary>
/// アプリケーション設定マネージャーの基底クラスです。
/// </summary>
/// <typeparam name="TApplicationSettings">アプリケーション設定の型</typeparam>
/// <param name="options">再読み込み可能なオプション値を取得するオブジェクト</param>
/// <param name="publisher">イベントを送信するパブリッシャー</param>
public abstract class ApplicationSettingsManagerBase<TApplicationSettings>(IReloadableOptions<TApplicationSettings> options, IPublisher publisher) : SettingsManagerBase<TApplicationSettings>(options, publisher), IApplicationSettingsManagerBase<TApplicationSettings>
    where TApplicationSettings : ApplicationSettingsBase
{
    /// <inheritdoc/>
    public override void NotifyAll(UpdateAllSettingsCommand command)
    {
        ArgumentNullException.ThrowIfNull(command);

        Notify(Value.Theme);

        if (Value.Window is null)
        {
            return;
        }

        Notify(new ChangeWindowStateCommand(command.ViewModel, Value.Window.State));
    }

    /// <inheritdoc/>
    public void Notify(ApplicationTheme theme)
    {
        Publisher.Publish(theme);
        Notify(Value with { Theme = theme });
    }

    /// <inheritdoc/>
    public void Notify(ChangeWindowStateCommand command)
    {
        ArgumentNullException.ThrowIfNull(command);

        if (Value.Window is null)
        {
            ThrowHelper.ThrowInvalidOperationException("Window settings are not initialized.");
        }

        Publisher.Publish(command);

        var newSettings = Value with { };
        newSettings.Window.State = command.State;
        Notify(newSettings);
    }
}
