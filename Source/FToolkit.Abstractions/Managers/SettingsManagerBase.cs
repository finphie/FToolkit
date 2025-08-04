using FToolkit.Objects;
using FToolkit.Options;
using FToolkit.Publishers;

namespace FToolkit.Managers;

/// <summary>
/// 設定マネージャーの基底クラスです。
/// </summary>
/// <typeparam name="T">アプリケーション設定の型</typeparam>
public class SettingsManagerBase<T> : ISettingsManagerBase<T>
    where T : ApplicationSettingsBase
{
    readonly IReloadableOptions<T> _options;
    readonly IPublisher _publisher;

    /// <summary>
    /// <see cref="SettingsManagerBase{T}"/>クラスの新しいインスタンスを初期化します。
    /// </summary>
    /// <param name="options">オプション値の取得を行うオブジェクト</param>
    /// <param name="publisher">イベントを送信するオブジェクト</param>
    public SettingsManagerBase(IReloadableOptions<T> options, IPublisher publisher)
    {
        ArgumentNullException.ThrowIfNull(options);
        ArgumentNullException.ThrowIfNull(publisher);

        _options = options;
        _publisher = publisher;
    }

    /// <inheritdoc/>
    public T Value => _options.Value;

    /// <inheritdoc/>
    public virtual void NotifyAll()
        => Notify(_options.Value.Theme);

    /// <inheritdoc/>
    public void Notify(ApplicationTheme theme)
        => _publisher.Publish(theme);
}
