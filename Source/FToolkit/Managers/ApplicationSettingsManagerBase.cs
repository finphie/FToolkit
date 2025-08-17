using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Diagnostics;
using FToolkit.Commands;
using FToolkit.Mappers;
using FToolkit.Objects;
using FToolkit.Options;
using FToolkit.Publishers;
using FToolkit.ViewModels;

namespace FToolkit.Managers;

/// <summary>
/// アプリケーション設定マネージャーの基底クラスです。
/// </summary>
/// <typeparam name="TApplicationSettings">アプリケーション設定の型</typeparam>
/// <param name="options">再読み込み可能なオプション値を取得するオブジェクト</param>
/// <param name="publisher">イベントを送信するオブジェクト</param>
public abstract class ApplicationSettingsManagerBase<TApplicationSettings>(IReloadableOptions<TApplicationSettings> options, IPublisher publisher) : SettingsManagerBase<TApplicationSettings>(options, publisher), IApplicationSettingsManagerBase
    where TApplicationSettings : ApplicationSettingsBase
{
    /// <inheritdoc/>
    public ApplicationTheme ApplicationTheme => Value.Theme.ToFToolkitObject();

    /// <inheritdoc/>
    public WindowState MainWindowState
    {
        get
        {
            var mainWindow = Value.MainWindow;

            ThrowIfMainWindowSettingsNotInitialized(mainWindow);
            return mainWindow.State.ToFToolkitObject();
        }
    }

    /// <inheritdoc/>
    public WindowSize? MainWindowSize
    {
        get
        {
            var mainWindow = Value.MainWindow;

            ThrowIfMainWindowSettingsNotInitialized(mainWindow);
            return mainWindow.Size?.ToFToolkitObject();
        }
    }

    /// <inheritdoc/>
    public override void NotifyAll(UpdateAllSettingsCommand command)
    {
        ArgumentNullException.ThrowIfNull(command);

        Notify(new ChangeApplicationThemeCommand(ApplicationTheme));
    }

    /// <inheritdoc/>
    public void Notify(ChangeApplicationThemeCommand command)
    {
        ArgumentNullException.ThrowIfNull(command);

        Publisher.Publish(command);
        Notify(Value with { Theme = command.ApplicationTheme.ToFToolkitSettings() });
    }

    /// <inheritdoc/>
    public virtual void Notify(ChangeWindowStateCommand command)
    {
        ArgumentNullException.ThrowIfNull(command);

        if (command.ViewModel is not IMainViewModel)
        {
            return;
        }

        ThrowIfMainWindowSettingsNotInitialized(Value.MainWindow);
        Publisher.Publish(command);

        var newSettings = Value with { };
        newSettings.MainWindow.State = command.State.ToFToolkitSettings();
        Notify(newSettings);
    }

    /// <inheritdoc/>
    public virtual void Notify(ChangeWindowSizeCommand command)
    {
        ArgumentNullException.ThrowIfNull(command);

        if (command.ViewModel is not IMainViewModel)
        {
            return;
        }

        ThrowIfMainWindowSettingsNotInitialized(Value.MainWindow);
        Publisher.Publish(command);

        var newSettings = Value with { };
        newSettings.MainWindow.Size = command.Size.ToFToolkitSettings();
        Notify(newSettings);
    }

    static void ThrowIfMainWindowSettingsNotInitialized([NotNull] WindowSettings? windowSettings)
    {
        if (windowSettings is not null)
        {
            return;
        }

        ThrowHelper.ThrowInvalidOperationException("MainWindow settings are not initialized.");
    }
}
