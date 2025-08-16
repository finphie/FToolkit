using FToolkit.Commands;
using FToolkit.Objects;

namespace FToolkit.Managers;

/// <summary>
/// アプリケーション設定マネージャーの基本インターフェイスです。
/// </summary>
/// <typeparam name="TSettings">設定の型</typeparam>
public interface IApplicationSettingsManagerBase<out TSettings> : ISettingsManagerBase<TSettings>
    where TSettings : ApplicationSettingsBase
{
    /// <summary>
    /// アプリケーションテーマの変更を通知します。
    /// </summary>
    /// <param name="command">コマンド</param>
    /// <exception cref="ArgumentNullException"><paramref name="command"/>が<see langword="null"/>です。</exception>
    void Notify(ChangeApplicationThemeCommand command);

    /// <summary>
    /// Windowの状態変更を通知します。
    /// </summary>
    /// <param name="command">コマンド</param>
    /// <exception cref="ArgumentNullException"><paramref name="command"/>が<see langword="null"/>です。</exception>
    void Notify(ChangeWindowStateCommand command);

    /// <summary>
    /// Windowサイズ変更を通知します。
    /// </summary>
    /// <param name="command">コマンド</param>
    /// <exception cref="ArgumentNullException"><paramref name="command"/>が<see langword="null"/>です。</exception>
    void Notify(ChangeWindowSizeCommand command);
}
