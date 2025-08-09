using Microsoft.Extensions.DependencyInjection;
using ZeroMessenger;

namespace FToolkit.Publishers;

/// <summary>
/// パブリッシャーのクラスです。
/// </summary>
sealed class Publisher : IPublisher
{
    readonly IServiceProvider _provider;

    /// <summary>
    /// <see cref="Publisher"/>クラスの新しいインスタンスを初期化します。
    /// </summary>
    /// <param name="provider">パブリッシャー取得に使用するサービスプロバイダー</param>
    public Publisher(IServiceProvider provider)
    {
        ArgumentNullException.ThrowIfNull(provider);
        _provider = provider;
    }

    /// <inheritdoc/>
    public void Publish<T>(T message)
    {
        var publisher = _provider.GetRequiredService<IMessagePublisher<T>>();
        publisher.Publish(message);
    }
}
