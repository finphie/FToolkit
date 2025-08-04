namespace FToolkit.Publishers;

/// <summary>
/// パブリッシャーのインターフェイスです。
/// </summary>
public interface IPublisher
{
    /// <summary>
    /// 指定したメッセージを発行します。
    /// </summary>
    /// <typeparam name="T">発行するメッセージの型</typeparam>
    /// <param name="message">発行するメッセージ</param>
    void Publish<T>(T message);
}
