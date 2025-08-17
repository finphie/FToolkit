namespace FToolkit.Objects;

/// <summary>
/// Windowのサイズ設定を表すクラスです。
/// </summary>
public sealed record WindowSizeSettings
{
    /// <summary>
    /// 幅
    /// </summary>
    public int Width { get; set; }

    /// <summary>
    /// 高さ
    /// </summary>
    public int Height { get; set; }
}
