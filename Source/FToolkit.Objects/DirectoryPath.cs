using UnitGenerator;

namespace FToolkit.Objects;

/// <summary>
/// ディレクトリのパスを表す構造体です。
/// </summary>
[UnitOf<string>(UnitGenerateOptions.Validate)]
public readonly partial struct DirectoryPath
{
    private partial void Validate()
        => ArgumentException.ThrowIfNullOrEmpty(value);
}
