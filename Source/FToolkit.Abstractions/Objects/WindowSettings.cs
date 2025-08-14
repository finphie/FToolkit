namespace FToolkit.Objects;

/// <summary>
/// Window設定を表すクラスです。
/// </summary>
public sealed record WindowSettings
{
    /// <summary>
    /// 幅
    /// </summary>
    public int Width { get; set; } = 1200;

    /// <summary>
    /// 高さ
    /// </summary>
    public int Height { get; set; } = 600;

    /// <summary>
    /// X座標
    /// </summary>
    public int Left { get; set; } = -1;

    /// <summary>
    /// Y座標
    /// </summary>
    public int Top { get; set; } = -1;

    /// <summary>
    /// 状態
    /// </summary>
    public WindowState State { get; set; } = WindowState.Normal;

    /// <summary>
    /// 最前面にするかどうか
    /// </summary>
    public bool IsAlwaysOnTop { get; set; }
}
