using FToolkit.Commands;

namespace FToolkit.Managers;

/// <summary>
/// 設定マネージャーの基本インターフェイスです。
/// </summary>
public interface ISettingsManagerBase
{
    /// <summary>
    /// すべての設定値を通知します。
    /// </summary>
    /// <param name="command">コマンド</param>
    /// <exception cref="ArgumentNullException"><paramref name="command"/>が<see langword="null"/>です。</exception>
    void NotifyAll(UpdateAllSettingsCommand command);
}
