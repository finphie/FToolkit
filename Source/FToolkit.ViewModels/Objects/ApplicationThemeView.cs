using FToolkit.Objects;

namespace FToolkit.ViewModels.Objects;

/// <summary>
/// アプリケーションテーマ
/// </summary>
/// <param name="Name">テーマ名</param>
/// <param name="Type">テーマの種類</param>
public sealed record ApplicationThemeView(string Name, ApplicationTheme Type)
{
    /// <inheritdoc/>
    public override string ToString()
        => Name;
}
