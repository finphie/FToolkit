using FToolkit.Repositories;

namespace FToolkit.Net.GitHub.Repositories.Entities;

/// <summary>
/// リクエスト情報を表すクラスです。
/// </summary>
/// <param name="Owner">オーナー名</param>
/// <param name="Name">リポジトリ名</param>
/// <param name="Entity">設定</param>
public sealed record Request(string Owner, string Name, Repository Entity) : IAggregateRoot;
