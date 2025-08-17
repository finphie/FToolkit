namespace FToolkit.Objects;

/// <summary>
/// Windowのサイズを表すクラスです。
/// </summary>
/// <param name="Width">幅</param>
/// <param name="Height">高さ</param>
public sealed record WindowSize(WindowWidth Width, WindowHeight Height);
