﻿using System.Text.Json.Serialization;

namespace FToolkit.Net.GitHub.Client.Entities;

/// <summary>
/// GitHubブランチ保護に関する設定を表すクラスです。
/// </summary>
/// <param name="EnforceAdmins">管理者にも適用するかどうか。</param>
/// <param name="RequiredLinearHistory">直線状の履歴を必須にするかどうか。</param>
/// <param name="AllowForcePushes">強制プッシュを許可するかどうか。</param>
/// <param name="AllowDeletions">プッシュアクセス権を持つユーザーが、保護されたブランチを削除できるようにするかどうか。</param>
/// <param name="RequiredConversationResolution">マージ前にコメントの解決を必須にするかどうか。</param>
/// <param name="RequiredStatusChecks">ステータスチェックに関するブランチ保護の設定。</param>
/// <param name="RequiredPullRequestReviews">レビューに関するブランチ保護の設定。</param>
public sealed record GitHubBranchProtection(
    bool EnforceAdmins = false,
    bool? RequiredLinearHistory = null,
    bool? AllowForcePushes = null,
    bool? AllowDeletions = null,
    bool? RequiredConversationResolution = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.Never)] GitHubBranchProtectionRequiredStatusChecks? RequiredStatusChecks = null,
    [property: JsonIgnore(Condition = JsonIgnoreCondition.Never)] GitHubBranchProtectionRequiredPullRequestReviews? RequiredPullRequestReviews = null)
{
    /// <summary>
    /// 保護されたブランチにプッシュできる人のリスト。
    /// </summary>
    /// <remarks>
    /// <para>このプロパティは使用していませんが、GitHub APIリクエストの際に必要です。</para>
    /// </remarks>
    [JsonInclude]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    internal object? Restrictions { get; }
}
