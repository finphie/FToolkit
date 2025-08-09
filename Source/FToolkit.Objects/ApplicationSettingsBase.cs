namespace FToolkit.Objects;

/// <summary>
/// アプリケーション設定を表す基底クラスです。
/// </summary>
public abstract record ApplicationSettingsBase
{
    /// <summary>
    /// アプリケーションテーマ
    /// </summary>
    public required ApplicationTheme Theme { get; set; }
}
