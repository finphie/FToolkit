using FToolkit.Commands;
using FToolkit.Views;
using ZeroMessenger;

namespace FToolkit.Subscribers;

/// <summary>
/// アプリケーションテーマ変更コマンドを受信し、テーマを変更するクラスです。
/// </summary>
sealed class ChangeApplicationThemeSubscriber : IDisposable
{
    readonly IDisposable _disposable;

    /// <summary>
    /// <see cref="ChangeApplicationThemeSubscriber"/>クラスの新しいインスタンスを初期化します。
    /// </summary>
    /// <param name="subscriber">アプリケーションテーマ変更イベントを受信するためのオブジェクト</param>
    /// <param name="themeOperations">アプリケーションテーマの操作を行うオブジェクト</param>
    public ChangeApplicationThemeSubscriber(IMessageSubscriber<ChangeApplicationThemeCommand> subscriber, IApplicationThemeOperations themeOperations)
    {
        ArgumentNullException.ThrowIfNull(subscriber);
        ArgumentNullException.ThrowIfNull(themeOperations);

        _disposable = subscriber.Subscribe(x => themeOperations.Change(x.ApplicationTheme));
    }

    /// <inheritdoc/>
    public void Dispose()
        => _disposable.Dispose();
}
