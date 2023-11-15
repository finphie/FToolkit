namespace FToolkit.Net.GitHub.Services.Settings;

/// <summary>
/// マージにおけるコミットタイトルの種類。
/// </summary>
public enum MergeCommitTitleType
{
    /// <summary>
    /// 変更なし
    /// </summary>
    Unchanged,

    /// <summary>
    /// プルリクエストのタイトル
    /// </summary>
    PullRequestTitle,

    /// <summary>
    /// マージメッセージのデフォルトのタイトル
    /// </summary>
    /// <remarks>
    /// <para>
    /// <example>
    /// Merge pull request #123 from branch-name
    /// </example>
    /// </para>
    /// </remarks>
    MergeMessage
}
