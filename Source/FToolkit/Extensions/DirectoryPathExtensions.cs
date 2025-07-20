using FToolkit.Objects;

namespace FToolkit.Extensions;

/// <summary>
/// <see cref="DirectoryPath"/>構造体関連の拡張メソッドです。
/// </summary>
public static class DirectoryPathExtensions
{
    /// <summary>
    /// ディレクトリのパスからディレクトリ名を取得します。
    /// </summary>
    /// <param name="directoryPath">ディレクトリのパス</param>
    /// <returns>現在のパスから抽出したディレクトリ名を表す<see cref="DirectoryName"/>オブジェクト。</returns>
    public static DirectoryName GetDirectoryName(this DirectoryPath directoryPath)
            => new(Path.GetDirectoryName(directoryPath.AsPrimitive()));
}
