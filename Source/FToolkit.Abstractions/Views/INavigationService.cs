using FToolkit.ViewModels;

namespace FToolkit.Views;

/// <summary>
/// 画面遷移を行うためのインターフェイスです。
/// </summary>
public interface INavigationService
{
    /// <summary>
    /// 指定したViewModelに関連付けられたViewへ遷移します。
    /// </summary>
    /// <typeparam name="TViewModel">遷移先のViewModel型</typeparam>
    /// <returns>このメソッドが完了すると、オブジェクトまたは値は返されません。</returns>
    /// <exception cref="InvalidOperationException">画面遷移に失敗しました。</exception>
    ValueTask NavigateToAsync<TViewModel>()
        where TViewModel : class, IViewModel;

    /// <summary>
    /// 前の画面へ戻ります。
    /// </summary>
    /// <returns>このメソッドが完了すると、オブジェクトまたは値は返されません。</returns>
    /// <exception cref="InvalidOperationException">画面遷移に失敗しました。</exception>
    ValueTask GoBackAsync();
}
