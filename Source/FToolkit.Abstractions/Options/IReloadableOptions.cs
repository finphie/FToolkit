namespace FToolkit.Options;

/// <summary>
/// 再読み込み可能なオプション値を取得するインターフェイスです。
/// </summary>
/// <typeparam name="T">オプションの種類</typeparam>
public interface IReloadableOptions<out T>
    where T : class
{
    /// <summary>
    /// 現在のオプション値を取得します。
    /// </summary>
    T Value { get; }
}
