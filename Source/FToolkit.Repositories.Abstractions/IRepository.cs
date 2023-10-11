using System.Diagnostics.CodeAnalysis;

namespace FToolkit.Repositories;

/// <summary>
/// Repositoryインターフェイスです。
/// </summary>
/// <typeparam name="T">集約ルートの型</typeparam>
[SuppressMessage("Design", "CA1040:空のインターフェイスは使用しません", Justification = "リポジトリクラス実装に必要。")]
public interface IRepository<T>
    where T : notnull, IAggregateRoot;
