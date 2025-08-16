namespace FToolkit.Objects;

/// <summary>
/// Window設定を表すクラスです。
/// </summary>
public sealed record WindowSettings
{
    /// <summary>
    /// サイズ
    /// </summary>
    public WindowSize Size { get; set; } = new(1200, 600);

    /// <summary>
    /// 状態
    /// </summary>
    public WindowState State { get; set; } = WindowState.Normal;

    /// <summary>
    /// 最前面にするかどうか
    /// </summary>
    public bool IsAlwaysOnTop { get; set; }
}
