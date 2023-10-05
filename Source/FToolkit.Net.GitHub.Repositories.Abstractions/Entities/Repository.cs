using FToolkit.Net.GitHub.Client.Entities;
using FToolkit.Net.GitHub.Repositories.Extensions;

namespace FToolkit.Net.GitHub.Repositories.Entities;

/// <summary>
/// GitHubリポジトリに関する設定を表すクラスです。
/// </summary>
/// <param name="HasIssues">Issuesを有効にするかどうか。</param>
/// <param name="HasProjects">Projectsを有効にするかどうか。</param>
/// <param name="HasWiki">Wikiを有効にするかどうか。</param>
/// <param name="HasDiscussions">Discussionsを有効にするかどうか。</param>
/// <param name="MergeCommit">マージにおけるコミットタイトル・メッセージの種類。</param>
/// <param name="SquashMergeCommit">スカッシュマージにおけるコミットメッセージの種類。</param>
/// <param name="AllowRebaseMerge">「Rebase and Merge」を有効にするかどうか。</param>
/// <param name="AllowAutoMerge">自動マージ機能を有効にするかどうか。</param>
/// <param name="DeleteBranchOnMerge">プルリクエストマージ時に、ブランチを自動的に削除するかどうか。</param>
/// <param name="AllowUpdateBranch">「Update branch」を有効にするかどうか。</param>
public sealed record Repository(
    Status HasIssues = Status.Unchanged,
    Status HasProjects = Status.Unchanged,
    Status HasWiki = Status.Unchanged,
    Status HasDiscussions = Status.Unchanged,
    MergeCommit? MergeCommit = null,
    SquashMergeCommit? SquashMergeCommit = null,
    Status AllowRebaseMerge = Status.Unchanged,
    Status AllowAutoMerge = Status.Unchanged,
    Status DeleteBranchOnMerge = Status.Unchanged,
    Status AllowUpdateBranch = Status.Unchanged)
{
    /// <summary>
    /// GitHub APIリクエスト時に必要となるクラスのインスタンスを取得します。
    /// </summary>
    /// <returns>リポジトリに関する設定を表すクラスのインスタンスを返します。</returns>
    public GitHubRepository ToGitHubRepository()
    {
        var entity = new GitHubRepository(
            HasIssues: HasIssues.ToBoolean(),
            HasProjects: HasProjects.ToBoolean(),
            HasWiki: HasWiki.ToBoolean(),
            HasDiscussions: HasDiscussions.ToBoolean(),
            AllowRebaseMerge: AllowRebaseMerge.ToBoolean(),
            AllowAutoMerge: AllowAutoMerge.ToBoolean(),
            DeleteBranchOnMerge: DeleteBranchOnMerge.ToBoolean(),
            AllowUpdateBranch: AllowUpdateBranch.ToBoolean());

        if (MergeCommit is not null)
        {
            entity = entity with
            {
                AllowMergeCommit = true,
                MergeCommitTitle = MergeCommit.Title.GetName(),
                MergeCommitMessage = MergeCommit.Message.GetName()
            };
        }

        if (SquashMergeCommit is not null)
        {
            entity = entity with
            {
                AllowSquashMerge = true,
                SquashMergeCommitTitle = SquashMergeCommit.Title.GetName(),
                SquashMergeCommitMessage = SquashMergeCommit.Message.GetName()
            };
        }

        return entity;
    }
}
