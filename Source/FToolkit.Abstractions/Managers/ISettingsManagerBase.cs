using FToolkit.Commands;
using FToolkit.Objects;

namespace FToolkit.Managers;

/// <summary>
/// 設定マネージャーの基本インターフェイスです。
/// </summary>
/// <typeparam name="TSettings">設定の型</typeparam>
public interface ISettingsManagerBase<out TSettings>
    where TSettings : ISettings
{
    /// <summary>
    /// 現在の設定値を取得します。
    /// </summary>
    TSettings Value { get; }

    /// <summary>
    /// すべての設定値を通知します。
    /// </summary>
    /// <param name="command">コマンド</param>
    void NotifyAll(UpdateAllSettingsCommand command);
}
