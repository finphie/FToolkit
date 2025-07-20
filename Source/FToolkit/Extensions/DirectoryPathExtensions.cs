using FToolkit.Objects;

namespace FToolkit.Extensions;

/// <summary>
/// <see cref="DirectoryPath"/>構造体関連の拡張メソッドです。
/// </summary>
public static class DirectoryPathExtensions
{
#pragma warning disable CA1034, CS1591, CA1822
    extension(DirectoryPath directoryPath)
#pragma warning restore CA1034, CS1591
    {
        /// <summary>
        /// ディレクトリのパスからディレクトリ名を取得します。
        /// </summary>
        /// <returns>現在のパスから抽出したディレクトリ名を表す<see cref="DirectoryName"/>オブジェクト。</returns>
        public DirectoryName GetDirectoryName()
            => new(Path.GetDirectoryName(directoryPath.AsPrimitive()));
    }
}
