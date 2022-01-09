using System.Buffers;
using CommunityToolkit.Diagnostics;

namespace FToolkit.IO.Helpers;

/// <summary>
/// パス関連のヘルパークラスです。
/// </summary>
public static class PathHelper
{
    // GUIDは36文字（ハイフンあり）
    const int GuidLength = 32 + 4;

    /// <summary>
    /// 拡張子なしの一時ファイル名を取得します。
    /// </summary>
    /// <returns>拡張子なしの一時ファイル名を返します。</returns>
    public static string GetTempFileNameWithoutExtension()
        => Guid.NewGuid().ToString();

    /// <summary>
    /// 拡張子なしの一時ファイル名を取得します。
    /// </summary>
    /// <param name="destination">拡張子なしの一時ファイル名</param>
    public static void GetTempFileNameWithoutExtension(Span<char> destination)
    {
        Guard.IsInRangeFor(GuidLength - 1, destination, nameof(destination));

        var guid = Guid.NewGuid();
        guid.TryFormat(destination, out _);
    }

    /// <summary>
    /// 一時ファイル名を取得します。
    /// </summary>
    /// <returns>一時ファイル名を返します。</returns>
    public static string GetTempFileName() => GetTempFileName(".tmp");

    /// <summary>
    /// 一時ファイル名を取得します。
    /// </summary>
    /// <param name="extension">拡張子</param>
    /// <returns>一時ファイル名を返します。</returns>
    public static string GetTempFileName(ReadOnlySpan<char> extension)
    {
        Guard.IsNotEmpty(extension, nameof(extension));
        Guard.IsInRangeFor(1, extension, nameof(extension));
        Guard.IsEqualTo(extension[0], '.', nameof(extension));

        const int StackallocThreshold = 512;

        var length = GuidLength + extension.Length;
        char[]? pool = null;
        Span<char> buffer = length <= StackallocThreshold
            ? stackalloc char[GuidLength + extension.Length]
            : (pool = ArrayPool<char>.Shared.Rent(length));

        try
        {
            GetTempFileName(extension, buffer);
        }
        finally
        {
            if (pool is not null)
            {
                ArrayPool<char>.Shared.Return(pool);
            }
        }

        return buffer.ToString();
    }

    /// <summary>
    /// 一時ファイル名を取得します。
    /// </summary>
    /// <param name="extension">拡張子</param>
    /// <param name="destination">一時ファイル名</param>
    public static void GetTempFileName(ReadOnlySpan<char> extension, Span<char> destination)
    {
        Guard.IsNotEmpty(extension, nameof(extension));
        Guard.IsInRangeFor(1, extension, nameof(extension));
        Guard.IsEqualTo(extension[0], '.', nameof(extension));
        Guard.IsInRangeFor(GuidLength + 2 - 1, destination, nameof(destination));

        GetTempFileNameWithoutExtension(destination);
        extension.CopyTo(destination[GuidLength..]);
    }

    /// <summary>
    /// 指定された拡張子の一時ファイルパスを取得します。
    /// </summary>
    /// <param name="extension">拡張子</param>
    /// <returns>指定された拡張子の一時ファイルパスを返します。</returns>
    public static string GetTempFilePath(ReadOnlySpan<char> extension)
    {
        Guard.IsNotEmpty(extension, nameof(extension));
        Guard.IsInRangeFor(1, extension, nameof(extension));
        Guard.IsEqualTo(extension[0], '.', nameof(extension));

        const int StackallocThreshold = 512;

        var length = GuidLength + extension.Length;
        char[]? pool = null;
        Span<char> buffer = length <= StackallocThreshold
            ? stackalloc char[GuidLength + extension.Length]
            : (pool = ArrayPool<char>.Shared.Rent(length));

        try
        {
            GetTempFileName(extension, buffer);
            return Path.Join(Path.GetTempPath(), buffer);
        }
        finally
        {
            if (pool is not null)
            {
                ArrayPool<char>.Shared.Return(pool);
            }
        }
    }
}
