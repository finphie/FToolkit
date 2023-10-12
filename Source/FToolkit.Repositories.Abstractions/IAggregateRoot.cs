using System.Diagnostics.CodeAnalysis;

namespace FToolkit.Repositories;

/// <summary>
/// 集約ルートを表すインターフェイスです。
/// </summary>
[SuppressMessage("Design", "CA1040:空のインターフェイスは使用しません", Justification = "エンティティクラス実装に必要。")]
public interface IAggregateRoot;
