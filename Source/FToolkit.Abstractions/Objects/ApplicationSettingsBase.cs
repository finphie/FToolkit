using System.Text.Json.Serialization;

namespace FToolkit.Objects;

/// <summary>
/// アプリケーション設定を表す基底クラスです。
/// </summary>
public abstract record ApplicationSettingsBase : ISettings
{
    /// <summary>
    /// アプリケーションテーマ
    /// </summary>
    public ApplicationTheme Theme { get; set; } = ApplicationTheme.System;

    /// <summary>
    /// Window設定
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public virtual WindowSettings? Window { get; set; }
}
