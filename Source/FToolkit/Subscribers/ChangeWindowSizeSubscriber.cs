using FToolkit.Commands;
using FToolkit.Views;
using ZeroMessenger;

namespace FToolkit.Subscribers;

/// <summary>
/// Windowのサイズ変更コマンドを受信して、Windowのサイズを変更するクラスです。
/// </summary>
sealed class ChangeWindowSizeSubscriber : IDisposable
{
    readonly IDisposable _disposable;

    /// <summary>
    /// <see cref="ChangeWindowSizeSubscriber"/>クラスの新しいインスタンスを初期化します。
    /// </summary>
    /// <param name="subscriber">Windowのサイズ変更コマンドを受信するためのオブジェクト</param>
    /// <param name="windowService">Window関連操作を行うオブジェクト</param>
    /// <exception cref="ArgumentNullException"><paramref name="subscriber"/>、<paramref name="windowService"/>が<see langword="null"/>です。</exception>
    public ChangeWindowSizeSubscriber(IMessageSubscriber<ChangeWindowSizeCommand> subscriber, IWindowService windowService)
    {
        ArgumentNullException.ThrowIfNull(subscriber);
        ArgumentNullException.ThrowIfNull(windowService);

        _disposable = subscriber.Subscribe(x => windowService.ChangeWindowSize(x.ViewModel, x.Size));
    }

    /// <inheritdoc/>
    public void Dispose()
        => _disposable.Dispose();
}
