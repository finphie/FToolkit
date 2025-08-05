using FToolkit.Objects;
using FToolkit.Options;
using ZeroMessenger;

namespace FToolkit.Subscribers;

/// <summary>
/// 設定変更要求を受信し、オプション値を更新するクラスです。
/// </summary>
/// <typeparam name="T">アプリケーション設定の型</typeparam>
public sealed class UpdateApplicationsSettingsSubscriber<T> : IDisposable
    where T : ApplicationSettingsBase
{
    readonly IDisposable _disposable;

    /// <summary>
    /// <see cref="UpdateApplicationsSettingsSubscriber{T}"/>クラスの新しいインスタンスを初期化します。
    /// </summary>
    /// <param name="themeSubscriber">アプリケーションテーマ変更イベントを受信するオブジェクト</param>
    /// <param name="writableOptions">オプション値を更新するオブジェクト</param>
    public UpdateApplicationsSettingsSubscriber(IMessageSubscriber<ApplicationTheme> themeSubscriber, IWritableOptions<T> writableOptions)
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
