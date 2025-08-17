using FToolkit.Commands;
using FToolkit.Objects;

namespace FToolkit.Managers;

/// <summary>
/// アプリケーション設定マネージャーの基本インターフェイスです。
/// </summary>
public interface IApplicationSettingsManagerBase : ISettingsManagerBase
{
    /// <summary>
    /// アプリケーションテーマを取得します。
    /// </summary>
    ApplicationTheme ApplicationTheme { get; }

    /// <summary>
    /// メインWindowの状態を取得します。
    /// </summary>
    /// <exception cref="InvalidOperationException">設定値が不正です。</exception>
    WindowState MainWindowState { get; }

    /// <summary>
    /// メインWindowのサイズを取得します。
    /// </summary>
    /// <exception cref="InvalidOperationException">設定値が不正です。</exception>
    WindowSize MainWindowSize { get; }

    /// <summary>
    /// アプリケーションテーマの変更を通知します。
    /// </summary>
    /// <param name="command">コマンド</param>
    /// <exception cref="ArgumentNullException"><paramref name="command"/>が<see langword="null"/>です。</exception>
    /// <exception cref="InvalidOperationException">設定値が不正です。</exception>
    void Notify(ChangeApplicationThemeCommand command);

    /// <summary>
    /// Windowの状態変更を通知します。
    /// </summary>
    /// <param name="command">コマンド</param>
    /// <exception cref="ArgumentNullException"><paramref name="command"/>が<see langword="null"/>です。</exception>
    /// <exception cref="InvalidOperationException">設定値が不正です。</exception>
    void Notify(ChangeWindowStateCommand command);

    /// <summary>
    /// Windowサイズ変更を通知します。
    /// </summary>
    /// <param name="command">コマンド</param>
    /// <exception cref="ArgumentNullException"><paramref name="command"/>が<see langword="null"/>です。</exception>
    /// <exception cref="InvalidOperationException">設定値が不正です。</exception>
    void Notify(ChangeWindowSizeCommand command);
}
