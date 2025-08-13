using FToolkit.Objects;
using FToolkit.Options;
using FToolkit.Publishers;

namespace FToolkit.Managers;

/// <summary>
/// 設定マネージャーを作成するファクトリークラスです。
/// </summary>
/// <typeparam name="TSettings">設定の型</typeparam>
/// <typeparam name="TSettingsManager">設定マネージャーの型</typeparam>
public sealed class SettingsManagerFactory<TSettings, TSettingsManager> : ISettingsManagerFactory<TSettings, TSettingsManager>
    where TSettings : ISettings
    where TSettingsManager : ISettingsManagerBase<TSettings, TSettingsManager>
{
    readonly IReloadableOptions<TSettings> _options;
    readonly IPublisher _publisher;

    /// <summary>
    /// <see cref="SettingsManagerFactory{TSettings, TSettingsManager}"/>クラスの新しいインスタンスを初期化します。
    /// </summary>
    /// <param name="options">オプション値の取得を行うオブジェクト</param>
    /// <param name="publisher">イベントを送信するオブジェクト</param>
    public SettingsManagerFactory(IReloadableOptions<TSettings> options, IPublisher publisher)
    {
        ArgumentNullException.ThrowIfNull(options);
        ArgumentNullException.ThrowIfNull(publisher);

        _options = options;
        _publisher = publisher;
    }

    /// <inheritdoc/>
    public TSettingsManager Create()
        => TSettingsManager.Create(_options, _publisher);
}
