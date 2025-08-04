using FToolkit.Objects;

namespace FToolkit.Managers;

/// <summary>
/// 設定マネージャーの基本インターフェイスです。
/// </summary>
/// <typeparam name="T">設定値の型</typeparam>
public interface ISettingsManagerBase<out T>
    where T : class
{
    /// <summary>
    /// 現在の設定値を取得します。
    /// </summary>
    T Value { get; }

    /// <summary>
    /// すべての設定値を通知します。
    /// </summary>
    void NotifyAll();

    /// <summary>
    /// アプリケーションテーマを通知します。
    /// </summary>
    /// <param name="theme">アプリケーションテーマ</param>
    void Notify(ApplicationTheme theme);
}
