using FToolkit.Objects;

namespace FToolkit.Commands;

/// <summary>
/// アプリケーションのテーマを変更するコマンドです。
/// </summary>
/// <param name="ApplicationTheme">アプリケーションテーマ</param>
public sealed record ChangeApplicationThemeCommand(ApplicationTheme ApplicationTheme);
