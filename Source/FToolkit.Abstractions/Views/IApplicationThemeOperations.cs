using FToolkit.Objects;

namespace FToolkit.Views;

/// <summary>
/// アプリケーションテーマを操作するインターフェイスです。
/// </summary>
public interface IApplicationThemeOperations
{
    /// <summary>
    /// 現在のアプリケーションテーマを取得します。
    /// </summary>
    /// <returns>現在のアプリケーションテーマ</returns>
    ApplicationTheme Get();

    /// <summary>
    /// アプリケーションのテーマを変更します。
    /// </summary>
    /// <param name="theme">新しいテーマ</param>
    void Change(ApplicationTheme theme);
}
