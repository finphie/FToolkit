using FToolkit.Repositories;

namespace FToolkit.Net.GitHub.Repositories.Entities;

/// <summary>
/// ブランチ識別情報を表すクラスです。
/// </summary>
/// <param name="Owner">オーナー名</param>
/// <param name="Name">リポジトリ名</param>
/// <param name="Branch">ブランチ名</param>
public record BranchIdentifierRequest(string Owner, string Name, string Branch) : IAggregateRoot;
