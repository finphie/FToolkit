namespace FToolkit;

/// <summary>
/// 1つの引数を使用して、インスタンスを生成するためのインターフェイスです。
/// </summary>
/// <typeparam name="TSelf">生成される型</typeparam>
/// <typeparam name="TArgument">生成時に使用する引数の型</typeparam>
public interface IConstructible<out TSelf, in TArgument>
{
    /// <summary>
    /// インスタンスを生成します。
    /// </summary>
    /// <param name="argument">生成時に使用する引数</param>
    /// <returns>生成されたインスタンスを返します。</returns>
    static abstract TSelf Create(TArgument argument);
}

/// <summary>
/// 2つの引数を使用して、インスタンスを生成するためのインターフェイスです。
/// </summary>
/// <typeparam name="TSelf">生成される型</typeparam>
/// <typeparam name="TArgument0">1番目の引数の型</typeparam>
/// <typeparam name="TArgument1">2番目の引数の型</typeparam>
public interface IConstructible<out TSelf, in TArgument0, in TArgument1>
{
    /// <summary>
    /// 2つの引数を使用して、インスタンスを生成します。
    /// </summary>
    /// <param name="argument0">1番目の引数</param>
    /// <param name="argument1">2番目の引数</param>
    /// <returns>生成されたインスタンスを返します。</returns>
    static abstract TSelf Create(TArgument0 argument0, TArgument1 argument1);
}

/// <summary>
/// 3つの引数を使用して、インスタンスを生成するためのインターフェイスです。
/// </summary>
/// <typeparam name="TSelf">生成される型</typeparam>
/// <typeparam name="TArgument0">1番目の引数の型</typeparam>
/// <typeparam name="TArgument1">2番目の引数の型</typeparam>
/// <typeparam name="TArgument2">3番目の引数の型</typeparam>
public interface IConstructible<out TSelf, in TArgument0, in TArgument1, in TArgument2>
{
    /// <summary>
    /// 3つの引数を使用してインスタンスを生成します。
    /// </summary>
    /// <param name="argument0">1番目の引数</param>
    /// <param name="argument1">2番目の引数</param>
    /// <param name="argument2">3番目の引数</param>
    /// <returns>生成されたインスタンスを返します。</returns>
    static abstract TSelf Create(TArgument0 argument0, TArgument1 argument1, TArgument2 argument2);
}
