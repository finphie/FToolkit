using System.Diagnostics.CodeAnalysis;
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

        Notify(new ChangeApplicationThemeCommand(Value.Theme));

        if (Value.Window is not { } windowSettings)
        {
            return;
        }

        Notify(new ChangeWindowStateCommand(command.ViewModel, windowSettings.State));
        Notify(new ChangeWindowSizeCommand(command.ViewModel, windowSettings.Size));
    }

    /// <inheritdoc/>
    public void Notify(ChangeApplicationThemeCommand command)
    {
        ArgumentNullException.ThrowIfNull(command);

        Publisher.Publish(command);
        Notify(Value with { Theme = command.ApplicationTheme });
    }

    /// <inheritdoc/>
    public void Notify(ChangeWindowStateCommand command)
    {
        ArgumentNullException.ThrowIfNull(command);
        ThrowIfWindowSettingsNotInitialized(Value.Window);

        Publisher.Publish(command);

        var newSettings = Value with { };
        newSettings.Window.State = command.State;
        Notify(newSettings);
    }

    /// <inheritdoc/>
    public void Notify(ChangeWindowSizeCommand command)
    {
        ArgumentNullException.ThrowIfNull(command);
        ThrowIfWindowSettingsNotInitialized(Value.Window);

        Publisher.Publish(command);

        var newSettings = Value with { };
        newSettings.Window.Size = command.Size;
        Notify(newSettings);
    }

    static void ThrowIfWindowSettingsNotInitialized([NotNull] WindowSettings? windowSettings)
    {
        if (windowSettings is not null)
        {
            return;
        }

        ThrowHelper.ThrowInvalidOperationException("Window settings are not initialized.");
    }
}
