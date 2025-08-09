namespace FToolkit.Objects;

/// <summary>
/// アプリケーション情報を保持する基底クラスです。
/// </summary>
public abstract record ApplicationInfoBase
{
    /// <summary>
    /// アプリケーションのタイトル
    /// </summary>
    public required string Title { get; init; }

    /// <summary>
    /// 作者名
    /// </summary>
    public required string Author { get; init; }
}
