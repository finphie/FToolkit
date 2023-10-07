using FToolkit.Net.GitHub.Services.Settings;

namespace FToolkit.Net.GitHub.Services.Extensions;

/// <summary>
/// GitHub設定関連の拡張メソッドです。
/// </summary>
static class GitHubSettingsExtensions
{
    /// <summary>
    /// <see cref="Status"/>型から<see cref="bool"/>型に変換します。
    /// </summary>
    /// <param name="status">ステータス</param>
    /// <returns>対応する<see cref="bool"/>型の値を返します。</returns>
    public static bool? ToBoolean(this Status status)
    {
        return status switch
        {
            Status.Unchanged => null,
            Status.Enabled => true,
            Status.Disabled => false,
            _ => null,
        };
    }

    /// <summary>
    /// <see cref="SquashMergeCommitTitleType"/>型を文字列に変換します。
    /// </summary>
    /// <param name="value">値</param>
    /// <returns>対応する文字列を返します。</returns>
    public static string? GetName(this SquashMergeCommitTitleType value)
    {
        return value switch
        {
            SquashMergeCommitTitleType.Unchanged => null,
            SquashMergeCommitTitleType.PullRequestTitle => "PR_TITLE",
            SquashMergeCommitTitleType.CommitOrPullRequestTitle => "COMMIT_OR_PR_TITLE",
            _ => null
        };
    }

    /// <summary>
    /// <see cref="SquashMergeCommitMessageType"/>型を文字列に変換します。
    /// </summary>
    /// <param name="value">値</param>
    /// <returns>対応する文字列を返します。</returns>
    public static string? GetName(this SquashMergeCommitMessageType value)
    {
        return value switch
        {
            SquashMergeCommitMessageType.Unchanged => null,
            SquashMergeCommitMessageType.PullRequestBody => "PR_BODY",
            SquashMergeCommitMessageType.CommitMessages => "COMMIT_MESSAGES",
            SquashMergeCommitMessageType.Blank => "BLANK",
            _ => null
        };
    }

    /// <summary>
    /// <see cref="MergeCommitTitleType"/>型を文字列に変換します。
    /// </summary>
    /// <param name="value">値</param>
    /// <returns>対応する文字列を返します。</returns>
    public static string? GetName(this MergeCommitTitleType value)
    {
        return value switch
        {
            MergeCommitTitleType.Unchanged => null,
            MergeCommitTitleType.PullRequestTitle => "PR_TITLE",
            MergeCommitTitleType.MergeMessage => "MERGE_MESSAGE",
            _ => null
        };
    }

    /// <summary>
    /// <see cref="MergeCommitMessageType"/>型を文字列に変換します。
    /// </summary>
    /// <param name="value">値</param>
    /// <returns>対応する文字列を返します。</returns>
    public static string? GetName(this MergeCommitMessageType value)
    {
        return value switch
        {
            MergeCommitMessageType.Unchanged => null,
            MergeCommitMessageType.PullRequestTitle => "PR_TITLE",
            MergeCommitMessageType.PullRequestBody => "PR_BODY",
            MergeCommitMessageType.Blank => "BLANK",
            _ => null
        };
    }
}
