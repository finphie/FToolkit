using FToolkit.Objects;
using FToolkit.Options;
using ZeroMessenger;

namespace FToolkit.Subscribers;

/// <summary>
/// 設定変更要求を受信し、オプション値を更新するクラスです。
/// </summary>
/// <typeparam name="T">アプリケーション設定の型</typeparam>
sealed class UpdateApplicationsSettingsSubscriber<T> : IDisposable
    where T : ApplicationSettingsBase
{
    readonly IDisposable _disposable;

    /// <summary>
    /// <see cref="UpdateApplicationsSettingsSubscriber{T}"/>クラスの新しいインスタンスを初期化します。
    /// </summary>
    /// <param name="subscriber">アプリケーション設定の変更イベントを受信するオブジェクト</param>
    /// <param name="writableOptions">オプション値を更新するオブジェクト</param>
    public UpdateApplicationsSettingsSubscriber(IMessageSubscriber<T> subscriber, IWritableOptions<T> writableOptions)
    {
        ArgumentNullException.ThrowIfNull(subscriber);
        ArgumentNullException.ThrowIfNull(writableOptions);

        _disposable = subscriber.SubscribeAwait(
            (settings, cancellationToken) => writableOptions.UpdateAsync(x => settings, cancellationToken),
            AsyncSubscribeStrategy.Switch);
    }

    /// <inheritdoc/>
    public void Dispose()
        => _disposable.Dispose();
}
