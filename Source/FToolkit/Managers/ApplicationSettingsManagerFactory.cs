using FToolkit.Objects;
using FToolkit.Options;
using FToolkit.Publishers;
using FToolkit.ViewModels;

namespace FToolkit.Managers;

/// <summary>
/// アプリケーション設定マネージャーを作成するファクトリークラスです。
/// </summary>
/// <typeparam name="TSettings">アプリケーション設定の型</typeparam>
/// <typeparam name="TSettingsManager">アプリケーション設定マネージャーの型</typeparam>
public sealed class ApplicationSettingsManagerFactory<TSettings, TSettingsManager> : IApplicationSettingsManagerFactory<TSettings, TSettingsManager>
    where TSettings : ApplicationSettingsBase
    where TSettingsManager : IApplicationSettingsManagerBase<TSettings, TSettingsManager>
{
    readonly IReloadableOptions<TSettings> _options;
    readonly IPublisher _publisher;

    /// <summary>
    /// <see cref="ApplicationSettingsManagerFactory{TSettings, TSettingsManager}"/>クラスの新しいインスタンスを初期化します。
    /// </summary>
    /// <param name="options">オプション値の取得を行うオブジェクト</param>
    /// <param name="publisher">イベントを送信するオブジェクト</param>
    public ApplicationSettingsManagerFactory(IReloadableOptions<TSettings> options, IPublisher publisher)
    {
        ArgumentNullException.ThrowIfNull(options);
        ArgumentNullException.ThrowIfNull(publisher);

        _options = options;
        _publisher = publisher;
    }

    /// <inheritdoc/>
    public TSettingsManager Create(IViewModel viewModel)
    {
        ArgumentNullException.ThrowIfNull(viewModel);
        return TSettingsManager.Create(_options, _publisher, viewModel);
    }
}
