﻿namespace FToolkit.Net.GitHub.Client.Entities;

/// <summary>
/// ステータスチェックに関するGitHubブランチ保護の設定を表すクラスです。
/// </summary>
/// <param name="Strict">マージする前にブランチを最新にする必要があるかどうか。</param>
/// <param name="Contexts">合格する必要があるステータスチェックのリスト。</param>
public sealed record GitHubBranchProtectionRequiredStatusChecks(
    bool Strict = false,
    IReadOnlyList<string>? Contexts = null);
