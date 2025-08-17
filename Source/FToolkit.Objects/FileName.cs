using UnitGenerator;

namespace FToolkit.Objects;

/// <summary>
/// ファイル名を表す構造体です。
/// </summary>
[UnitOf<string>(UnitGenerateOptions.Validate)]
public readonly partial struct FileName
{
    private partial void Validate()
        => ArgumentException.ThrowIfNullOrEmpty(value);
}
