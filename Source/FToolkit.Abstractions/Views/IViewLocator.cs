using FToolkit.ViewModels;

namespace FToolkit.Views;

/// <summary>
/// 指定されたViewModelに対するViewを取得するためのインターフェイスです。
/// </summary>
public interface IViewLocator
{
    /// <summary>
    /// 指定した型に関連付けられたViewを取得します。
    /// </summary>
    /// <typeparam name="T">取得するViewの型</typeparam>
    /// <returns>指定した型<typeparamref name="T"/>に対応する<see cref="IViewFor{T}"/>のインスタンスを返します。</returns>
    /// <exception cref="InvalidOperationException">対応するViewが見つかりません。</exception>
    IViewFor<T> GetView<T>()
        where T : class, IViewModel;
}
