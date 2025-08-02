namespace FToolkit.Options;

/// <summary>
/// オプション値を更新するためのインターフェイスです。
/// </summary>
/// <typeparam name="T">オプションの種類</typeparam>
public interface IWritableOptions<T>
    where T : class
{
    /// <summary>
    /// オプション値に変更を適用します。
    /// </summary>
    /// <param name="applyChanges">現在の値を受け取り、変更後の値を返すデリゲート</param>
    /// <param name="cancellationToken">キャンセル要求を行うためのトークン</param>
    /// <returns>このメソッドが完了すると、オブジェクトまたは値は返されません。</returns>
    ValueTask UpdateAsync(Func<T, T> applyChanges, CancellationToken cancellationToken = default);
}
