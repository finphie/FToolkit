using FToolkit.Objects;
using FToolkit.Options;
using FToolkit.Publishers;

namespace FToolkit.Managers;

/// <summary>
/// 設定マネージャーを作成するファクトリークラスです。
/// </summary>
/// <typeparam name="TSettings">設定の型</typeparam>
public sealed class SettingsManagerFactory<TSettings> : ISettingsManagerFactory<TSettings>
    where TSettings : ISettings
{
    readonly IReloadableOptions<TSettings> _options;
    readonly IPublisher _publisher;

    /// <summary>
    /// <see cref="SettingsManagerFactory{TSettings}"/>クラスの新しいインスタンスを初期化します。
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
    public TSettingsManager Create<TSettingsManager>()
        where TSettingsManager : ISettingsManagerBase<TSettings>, IConstructible<TSettingsManager, IReloadableOptions<TSettings>, IPublisher>
        => TSettingsManager.Create(_options, _publisher);

    /// <inheritdoc/>
    public TSettingsManager Create<TSettingsManager, TArgument>(TArgument argument)
        where TSettingsManager : ISettingsManagerBase<TSettings>, IConstructible<TSettingsManager, IReloadableOptions<TSettings>, IPublisher, TArgument>
    {
        ArgumentNullException.ThrowIfNull(argument);
        return TSettingsManager.Create(_options, _publisher, argument);
    }
}
