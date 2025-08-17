using FToolkit.Commands;
using FToolkit.Views;
using ZeroMessenger;

namespace FToolkit.Subscribers;

/// <summary>
/// Windowの状態変更コマンドを受信して、Windowの状態を変更するクラスです。
/// </summary>
sealed class ChangeWindowStateSubscriber : IDisposable
{
    readonly IDisposable _disposable;

    /// <summary>
    /// <see cref="ChangeWindowStateSubscriber"/>クラスの新しいインスタンスを初期化します。
    /// </summary>
    /// <param name="subscriber">Windowの状態変更コマンドを受信するためのオブジェクト</param>
    /// <param name="windowService">Window関連操作を行うオブジェクト</param>
    /// <exception cref="ArgumentNullException"><paramref name="subscriber"/>、<paramref name="windowService"/>が<see langword="null"/>です。</exception>
    public ChangeWindowStateSubscriber(IMessageSubscriber<ChangeWindowStateCommand> subscriber, IWindowService windowService)
    {
        ArgumentNullException.ThrowIfNull(subscriber);
        ArgumentNullException.ThrowIfNull(windowService);

        _disposable = subscriber.Subscribe(x => windowService.ChangeWindowState(x.ViewModel, x.State));
    }

    /// <inheritdoc/>
    public void Dispose()
        => _disposable.Dispose();
}
