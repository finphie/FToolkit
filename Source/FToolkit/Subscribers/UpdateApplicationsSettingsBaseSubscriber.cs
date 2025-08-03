using FToolkit.Objects;
using FToolkit.Options;
using ZeroMessenger;

namespace FToolkit.Subscribers;

/// <summary>
/// 設定変更要求を受信し、オプション値を更新するクラスです。
/// </summary>
/// <typeparam name="T">オプションの種類</typeparam>
public sealed class UpdateApplicationsSettingsBaseSubscriber : IDisposable
{
    readonly IDisposable _disposable;

    /// <summary>
    /// <see cref="UpdateApplicationsSettingsBaseSubscriber"/>クラスの新しいインスタンスを初期化します。
    /// </summary>
    /// <param name="themeSubscriber">アプリケーションテーマ変更イベントを受信するオブジェクト</param>
    /// <param name="writableOptions">オプション値を更新するオブジェクト</param>
    public UpdateApplicationsSettingsBaseSubscriber(IMessageSubscriber<ApplicationTheme> themeSubscriber, IWritableOptions<ApplicationSettingsBase> writableOptions)
    {
        ArgumentNullException.ThrowIfNull(themeSubscriber);
        ArgumentNullException.ThrowIfNull(writableOptions);

        _disposable = themeSubscriber.SubscribeAwait(
            (theme, cancellationToken) => writableOptions.UpdateAsync(x => x with { Theme = theme }, cancellationToken),
            AsyncSubscribeStrategy.Switch);
    }

    /// <inheritdoc/>
    public void Dispose()
        => _disposable.Dispose();
}
