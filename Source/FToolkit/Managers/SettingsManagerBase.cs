using FToolkit.Commands;
using FToolkit.Objects;
using FToolkit.Options;
using FToolkit.Publishers;
using Microsoft.Extensions.Logging;

namespace FToolkit.Managers;

/// <summary>
/// 設定マネージャーの基底クラスです。
/// </summary>
/// <typeparam name="TSettings">アプリケーション設定の型</typeparam>
public abstract partial class SettingsManagerBase<TSettings> : ISettingsManagerBase
    where TSettings : ISettings
{
    readonly IReloadableOptions<TSettings> _options;

    /// <summary>
    /// <see cref="SettingsManagerBase{TSettings}"/>クラスの新しいインスタンスを初期化します。
    /// </summary>
    /// <param name="logger">ログを記録するオブジェクト</param>
    /// <param name="options">オプション値の取得を行うオブジェクト</param>
    /// <param name="publisher">イベントを送信するオブジェクト</param>
    /// <exception cref="ArgumentNullException"><paramref name="logger"/>、<paramref name="options"/>、<paramref name="publisher"/>が<see langword="null"/>です。</exception>
    protected SettingsManagerBase(ILogger<SettingsManagerBase<TSettings>> logger, IReloadableOptions<TSettings> options, IPublisher publisher)
    {
        ArgumentNullException.ThrowIfNull(logger);
        ArgumentNullException.ThrowIfNull(options);
        ArgumentNullException.ThrowIfNull(publisher);

        Logger = logger;
        _options = options;
        Publisher = publisher;
    }

    /// <summary>
    /// ログを記録するオブジェクト
    /// </summary>
    protected ILogger<SettingsManagerBase<TSettings>> Logger { get; }

    /// <summary>
    /// 現在の設定値を取得します。
    /// </summary>
    protected TSettings Value => _options.Value;

    /// <summary>
    /// パブリッシャーを取得します。
    /// </summary>
    protected IPublisher Publisher { get; }

    /// <inheritdoc/>
    public abstract void NotifyAll(UpdateAllSettingsCommand command);

    /// <summary>
    /// アプリケーション設定の変更を通知します。
    /// </summary>
    /// <param name="settings">アプリケーション設定</param>
    protected void Notify(TSettings settings)
    {
        LogNotifyingSettingsUpdate();
        Publisher.Publish(settings);
    }

    [LoggerMessage(Level = LogLevel.Information, Message = "Notifying settings update.")]
    partial void LogNotifyingSettingsUpdate();
}
