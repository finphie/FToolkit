using UnitGenerator;

namespace FToolkit.Objects;

/// <summary>
/// Windowの幅を表す構造体です。
/// </summary>
[UnitOf<double>(UnitGenerateOptions.Validate)]
public readonly partial struct WindowWidth
{
    private partial void Validate()
        => ArgumentOutOfRangeException.ThrowIfNegative(value);
}
