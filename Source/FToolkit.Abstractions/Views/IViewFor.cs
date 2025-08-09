using FToolkit.ViewModels;

namespace FToolkit.Views;

/// <summary>
/// 指定のViewModel型に関連付けられたViewを表すインターフェイスです。
/// </summary>
/// <typeparam name="T">Viewに関連付けられるViewModelの型</typeparam>
public interface IViewFor<out T>
    where T : class, IViewModel
{
    /// <summary>
    /// 関連付けられたViewModelを取得します。
    /// </summary>
    T ViewModel { get; }
}
