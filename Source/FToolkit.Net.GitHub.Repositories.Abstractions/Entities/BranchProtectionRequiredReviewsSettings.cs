using FToolkit.Net.GitHub.Client.Entities;

namespace FToolkit.Net.GitHub.Repositories.Entities;

/// <summary>
/// レビューに関するGitHubブランチ保護の設定を表すクラスです。
/// </summary>
/// <param name="DismissStaleReviews">新しいコミットがプッシュされたときに、承認済みのレビューを却下するかどうか。</param>
/// <param name="RequireCodeOwnerReviews">コード所有者のレビューが必須かどうか。</param>
/// <param name="RequiredApprovingReviewCount"> プルリクエストの承認に必要なレビュアーの数。</param>
public sealed record BranchProtectionRequiredReviewsSettings(
    bool DismissStaleReviews = false,
    bool RequireCodeOwnerReviews = false,
    int RequiredApprovingReviewCount = 1)
{
    /// <summary>
    /// GitHub APIリクエスト時に必要となるクラスのインスタンスを取得します。
    /// </summary>
    /// <returns>ブランチ保護に関する設定を表すクラスのインスタンスを返します。</returns>
    internal GitHubBranchProtectionRequiredReviews ToEntity()
    {
        return new(
            DismissStaleReviews: DismissStaleReviews,
            RequireCodeOwnerReviews: RequireCodeOwnerReviews,
            RequiredApprovingReviewCount: RequiredApprovingReviewCount);
    }
}
