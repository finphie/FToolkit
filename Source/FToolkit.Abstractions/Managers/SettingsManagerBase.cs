using FToolkit.Objects;
using FToolkit.Options;
using FToolkit.Publishers;

namespace FToolkit.Managers;

/// <summary>
/// 設定マネージャーの基底クラスです。
/// </summary>
/// <typeparam name="T">アプリケーション設定の型</typeparam>
public abstract class SettingsManagerBase<T> : ISettingsManagerBase<T>
    where T : ApplicationSettingsBase
{
    readonly IReloadableOptions<T> _options;

    /// <summary>
    /// <see cref="SettingsManagerBase{T}"/>クラスの新しいインスタンスを初期化します。
    /// </summary>
    /// <param name="options">オプション値の取得を行うオブジェクト</param>
    /// <param name="publisher">イベントを送信するオブジェクト</param>
    protected SettingsManagerBase(IReloadableOptions<T> options, IPublisher publisher)
    {
        ArgumentNullException.ThrowIfNull(options);
        ArgumentNullException.ThrowIfNull(publisher);

        _options = options;
        Publisher = publisher;
    }

    /// <inheritdoc/>
    public T Value => _options.Value;

    /// <summary>
    /// パブリッシャーを取得します。
    /// </summary>
    protected IPublisher Publisher { get; }

    /// <inheritdoc/>
    public virtual void NotifyAll()
        => Notify(Value.Theme);

    /// <inheritdoc/>
    public void Notify(ApplicationTheme theme)
    {
        Publisher.Publish(theme);
        Notify(Value with { Theme = theme });
    }

    /// <summary>
    /// アプリケーション設定の変更を通知します。
    /// </summary>
    /// <param name="settings">アプリケーション設定</param>
    protected void Notify(T settings)
        => Publisher.Publish(settings);
}
