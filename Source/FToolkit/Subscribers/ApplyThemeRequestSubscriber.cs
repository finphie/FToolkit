using FToolkit.Objects;
using FToolkit.Views;
using ZeroMessenger;

namespace FToolkit.Subscribers;

/// <summary>
/// アプリケーションテーマ変更要求を受信し、テーマを適用するクラスです。
/// </summary>
public sealed class ApplyThemeRequestSubscriber : IDisposable
{
    readonly IDisposable _disposable;

    /// <summary>
    /// <see cref="ApplyThemeRequestSubscriber"/>クラスの新しいインスタンスを初期化します。
    /// </summary>
    /// <param name="subscriber">アプリケーションテーマ変更イベントを受信するためのオブジェクト</param>
    /// <param name="themeOperations">アプリケーションテーマの操作を行うためのオブジェクト</param>
    public ApplyThemeRequestSubscriber(IMessageSubscriber<ApplicationTheme> subscriber, IApplicationThemeOperations themeOperations)
    {
        ArgumentNullException.ThrowIfNull(subscriber);
        ArgumentNullException.ThrowIfNull(themeOperations);

        _disposable = subscriber.Subscribe(themeOperations.Change);
    }

    /// <inheritdoc/>
    public void Dispose()
        => _disposable.Dispose();
}
