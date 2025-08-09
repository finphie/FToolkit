using FToolkit.ViewModels;

namespace FToolkit.Views;

/// <summary>
/// ViewModelに関連付けられたWindowを表示するインターフェイスです。
/// </summary>
public interface IWindowService
{
    /// <summary>
    /// 指定したViewModelに関連付けられたWindowを表示します。
    /// </summary>
    /// <typeparam name="TViewModel">表示するWindowに関連付けられたViewModelの型</typeparam>
    /// <exception cref="InvalidOperationException">Windowの表示に失敗しました。</exception>
    void Show<TViewModel>()
        where TViewModel : class, IViewModel;

    /// <summary>
    /// 親Windowを指定して、ViewModelに関連付けられたWindowを表示します。
    /// </summary>
    /// <typeparam name="TOwnerViewModel">親となるWindowに関連付けられたViewModelの型</typeparam>
    /// <typeparam name="TViewModel">表示するWindowに関連付けられたViewModelの型</typeparam>
    /// <param name="ownerViewModel">親となるWindowに関連付けられたViewModel</param>
    /// <exception cref="InvalidOperationException">Windowの表示に失敗しました。</exception>
    void Show<TOwnerViewModel, TViewModel>(TOwnerViewModel ownerViewModel)
        where TOwnerViewModel : class, IViewModel
        where TViewModel : class, IViewModel;

    /// <summary>
    /// 指定したViewModelに関連付けられたWindowをダイアログとして表示します。
    /// </summary>
    /// <typeparam name="TViewModel">表示するWindowに関連付けられたViewModelの型</typeparam>
    /// <exception cref="InvalidOperationException">Windowの表示に失敗しました。</exception>
    void ShowDialog<TViewModel>()
        where TViewModel : class, IViewModel;

    /// <summary>
    /// 親Windowを指定して、ViewModelに関連付けられたWindowをダイアログとして表示します。
    /// </summary>
    /// <typeparam name="TOwnerViewModel">親となるWindowに関連付けられたViewModelの型</typeparam>
    /// <typeparam name="TViewModel">表示するWindowに関連付けられたViewModelの型</typeparam>
    /// <param name="ownerViewModel">親となるWindowに関連付けられたViewModel</param>
    /// <exception cref="InvalidOperationException">Windowの表示に失敗しました。</exception>
    void ShowDialog<TOwnerViewModel, TViewModel>(TOwnerViewModel ownerViewModel)
        where TOwnerViewModel : class, IViewModel
        where TViewModel : class, IViewModel;
}
