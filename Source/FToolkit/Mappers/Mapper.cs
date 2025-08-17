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

    /// <summary>
    /// <see cref="WindowStateSettings"/>を<see cref="WindowState"/>に変換します。
    /// </summary>
    /// <param name="settings">変換元の<see cref="WindowStateSettings"/></param>
    /// <returns>変換後の<see cref="WindowState"/>を返します。</returns>
    public static partial WindowState ToFToolkitObject(this WindowStateSettings settings);

    /// <summary>
    /// <see cref="WindowState"/>を<see cref="WindowStateSettings"/>に変換します。
    /// </summary>
    /// <param name="windowState">変換元の<see cref="WindowState"/></param>
    /// <returns>変換後の<see cref="WindowStateSettings"/>を返します。</returns>
    public static partial WindowStateSettings ToFToolkitSettings(this WindowState windowState);

    /// <summary>
    /// <see cref="WindowSizeSettings"/>を<see cref="WindowSize"/>に変換します。
    /// </summary>
    /// <param name="settings">変換元の<see cref="WindowSizeSettings"/></param>
    /// <returns>変換後の<see cref="WindowSize"/>を返します。</returns>
    public static partial WindowSize ToFToolkitObject(this WindowSizeSettings settings);

    /// <summary>
    /// <see cref="WindowSize"/>を<see cref="WindowSizeSettings"/>に変換します。
    /// </summary>
    /// <param name="windowSize">変換元の<see cref="WindowSize"/></param>
    /// <returns>変換後の<see cref="WindowSizeSettings"/>を返します。</returns>
    public static partial WindowSizeSettings ToFToolkitSettings(this WindowSize windowSize);
}
