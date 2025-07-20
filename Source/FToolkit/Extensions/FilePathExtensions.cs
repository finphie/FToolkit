using FToolkit.Objects;

namespace FToolkit.Extensions;

/// <summary>
/// <see cref="FilePath"/>構造体関連の拡張メソッドです。
/// </summary>
public static class FilePathExtensions
{
#pragma warning disable CA1034, CS1591, CA1822
    extension(FilePath filePath)
#pragma warning restore CA1034, CS1591
    {
        /// <summary>
        /// ファイルパスからファイル名を取得します。
        /// </summary>
        /// <returns>現在のパスから抽出したファイル名を表す<see cref="FileName"/>オブジェクト。</returns>
        public FileName GetFileName()
            => new(Path.GetFileName(filePath.AsPrimitive()));

        /// <summary>
        /// ファイルパスに拡張子が含まれているかどうかを判定します。
        /// </summary>
        /// <returns>拡張子が含まれている場合は<see langword="true"/>、含まれていない場合は<see langword="false"/>を返します。</returns>
        public bool HasExtension()
            => Path.HasExtension(filePath.AsPrimitive());
    }
}
