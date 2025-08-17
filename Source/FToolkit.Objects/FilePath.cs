using UnitGenerator;

namespace FToolkit.Objects;

/// <summary>
/// ファイルパスを表す構造体です。
/// </summary>
[UnitOf<string>(UnitGenerateOptions.Validate)]
public readonly partial struct FilePath
{
    private partial void Validate()
        => ArgumentException.ThrowIfNullOrEmpty(value);
}
