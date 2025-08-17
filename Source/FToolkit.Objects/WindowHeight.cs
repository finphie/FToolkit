using UnitGenerator;

namespace FToolkit.Objects;

/// <summary>
/// Windowの高さを表す構造体です。
/// </summary>
[UnitOf<double>(UnitGenerateOptions.Validate)]
public readonly partial struct WindowHeight
{
    private partial void Validate()
        => ArgumentOutOfRangeException.ThrowIfNegative(value);
}
