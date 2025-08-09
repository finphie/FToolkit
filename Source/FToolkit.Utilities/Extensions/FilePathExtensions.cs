using FToolkit.Objects;

namespace FToolkit.Extensions;

/// <summary>
/// <see cref="FilePath"/>構造体関連の拡張メソッドです。
/// </summary>
public static class FilePathExtensions
{
    /// <summary>
    /// ファイルパスからファイル名を取得します。
    /// </summary>
    /// <param name="filePath">ファイルパス</param>
    /// <returns>現在のパスから抽出したファイル名を表す<see cref="FileName"/>オブジェクト。</returns>
    public static FileName GetFileName(this FilePath filePath)
        => new(Path.GetFileName(filePath.AsPrimitive()));

    /// <summary>
    /// ファイルパスに拡張子が含まれているかどうかを判定します。
    /// </summary>
    /// <param name="filePath">ファイルパス</param>
    /// <returns>拡張子が含まれている場合は<see langword="true"/>、含まれていない場合は<see langword="false"/>を返します。</returns>
    public static bool HasExtension(this FilePath filePath)
        => Path.HasExtension(filePath.AsPrimitive());
}
