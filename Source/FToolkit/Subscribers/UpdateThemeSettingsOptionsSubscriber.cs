using FToolkit.Objects;
using FToolkit.Options;
using ZeroMessenger;

namespace FToolkit.Subscribers;

/// <summary>
/// 設定変更要求を受信し、オプション値を更新するクラスです。
/// </summary>
/// <typeparam name="T">オプションの種類</typeparam>
public sealed class UpdateThemeSettingsOptionsSubscriber<T> : IDisposable
    where T : ApplicationSettingsBase
{
    readonly IDisposable _disposable;

    /// <summary>
    /// <see cref="UpdateThemeSettingsOptionsSubscriber{T}"/>クラスの新しいインスタンスを初期化します。
    /// </summary>
    /// <param name="subscriber">アプリケーションテーマ変更イベントを受信するためのオブジェクト</param>
    public UpdateThemeSettingsOptionsSubscriber(IMessageSubscriber<ApplicationTheme> subscriber, IWritableOptions<T> writableOptions)
    {
        ArgumentNullException.ThrowIfNull(subscriber);
        ArgumentNullException.ThrowIfNull(writableOptions);

        _disposable = subscriber.SubscribeAwait(
            (theme, cancellationToken) => writableOptions.UpdateAsync(x => x with { Theme = theme }, cancellationToken),
            AsyncSubscribeStrategy.Switch);
    }

    /// <inheritdoc/>
    public void Dispose()
        => _disposable.Dispose();
}
