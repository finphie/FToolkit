using FToolkit.Repositories;

namespace FToolkit.Net.GitHub.Repositories.Entities;

/// <summary>
/// ブランチ情報を表すクラスです。
/// </summary>
/// <param name="Owner">オーナー名</param>
/// <param name="Name">リポジトリ名</param>
/// <param name="Branch">ブランチ名</param>
/// <param name="Settings">設定</param>
public sealed record BranchRequest(string Owner, string Name, string Branch, BranchProtectionSettings? Settings = null) : IAggregateRoot;
