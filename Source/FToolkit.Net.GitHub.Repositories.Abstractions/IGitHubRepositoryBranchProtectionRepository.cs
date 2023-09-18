using FToolkit.Net.GitHub.Repositories.Entities;
using FToolkit.Repositories;

namespace FToolkit.Net.GitHub.Repositories;

/// <summary>
/// GitHubブランチ保護設定に関する操作を定義するインターフェイスです。
/// </summary>
public interface IGitHubRepositoryBranchProtectionRepository : IRepository<BranchRequest>
{
    /// <summary>
    /// 指定されたリクエスト情報で更新処理を実行します。
    /// </summary>
    /// <param name="request">リクエスト情報。</param>
    /// <param name="cancellationToken">キャンセル要求を行うためのトークン。</param>
    /// <returns>このメソッドが完了すると、オブジェクトまたは値は返されません。</returns>
    /// <exception cref="ArgumentNullException"><paramref name="request"/>がnullです。</exception>
    Task UpdateAsync(BranchRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// 指定されたリクエスト情報で削除処理を実行します。
    /// </summary>
    /// <param name="request">リクエスト情報。</param>
    /// <param name="cancellationToken">キャンセル要求を行うためのトークン。</param>
    /// <returns>このメソッドが完了すると、オブジェクトまたは値は返されません。</returns>
    /// <exception cref="ArgumentNullException"><paramref name="request"/>がnullです。</exception>
    Task DeleteAsync(BranchRequest request, CancellationToken cancellationToken = default);
}
