using System.Text.Json.Serialization;

namespace FToolkit.Objects;

/// <summary>
/// Window設定を表すクラスです。
/// </summary>
public sealed record WindowSettings
{
    /// <summary>
    /// サイズ
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public WindowSizeSettings? Size { get; set; }

    /// <summary>
    /// 状態
    /// </summary>
    public WindowStateSettings State { get; set; } = WindowStateSettings.Normal;

    /// <summary>
    /// 最前面にするかどうか
    /// </summary>
    public bool IsAlwaysOnTop { get; set; }
}
