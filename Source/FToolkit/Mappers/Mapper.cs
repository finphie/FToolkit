using FToolkit.Objects;
using Riok.Mapperly.Abstractions;

namespace FToolkit.Mappers;

/// <summary>
/// マッピングを行う拡張メソッドです。
/// </summary>
[Mapper(EnumMappingStrategy = EnumMappingStrategy.ByName)]
static partial class Mapper
{
    /// <summary>
    /// <see cref="ApplicationThemeSettings"/>を<see cref="ApplicationTheme"/>に変換します。
    /// </summary>
    /// <param name="settings">変換元の<see cref="ApplicationThemeSettings"/></param>
    /// <returns>変換後の<see cref="ApplicationTheme"/>を返します。</returns>
    public static partial ApplicationTheme ToFToolkitObject(this ApplicationThemeSettings settings);

    /// <summary>
    /// <see cref="ApplicationTheme"/>を<see cref="ApplicationThemeSettings"/>に変換します。
    /// </summary>
    /// <param name="applicationTheme">変換元の<see cref="ApplicationTheme"/></param>
    /// <returns>変換後の<see cref="ApplicationThemeSettings"/>を返します。</returns>
    public static partial ApplicationThemeSettings ToFToolkitSettings(this ApplicationTheme applicationTheme);
}
