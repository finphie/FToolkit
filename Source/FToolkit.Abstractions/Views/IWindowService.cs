using FToolkit.Objects;
using FToolkit.ViewModels;
using R3;

namespace FToolkit.Views;

/// <summary>
/// ViewModelに関連付けられたWindow関連操作を行うインターフェイスです。
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

    /// <summary>
    /// 指定したViewModelに関連付けられたWindowの状態を変更します。
    /// </summary>
    /// <typeparam name="TViewModel">状態を変更するWindowに関連付けられたViewModelの型</typeparam>
    /// <param name="viewModel">状態を変更するWindowに関連付けられたViewModel</param>
    /// <param name="windowState">Windowの状態</param>
    void ChangeWindowState<TViewModel>(TViewModel viewModel, WindowState windowState)
        where TViewModel : class, IViewModel;

    /// <summary>
    /// 指定したViewModelに関連付けられたWindowの状態変更を監視します。
    /// </summary>
    /// <typeparam name="TViewModel">状態変更を監視するWindowに関連付けられたViewModelの型</typeparam>
    /// <param name="viewModel">状態変更を監視するWindowに関連付けられたViewModel</param>
    /// <returns>Windowの状態変更を通知するObservableを返します。</returns>
    Observable<WindowState> ObserveWindowStateChanged<TViewModel>(TViewModel viewModel)
        where TViewModel : class, IViewModel;

    /// <summary>
    /// 指定したViewModelに関連付けられたWindowのサイズを変更します。
    /// </summary>
    /// <typeparam name="TViewModel">サイズを変更するWindowに関連付けられたViewModelの型</typeparam>
    /// <param name="viewModel">サイズを変更するWindowに関連付けられたViewModel</param>
    /// <param name="windowSize">Windowのサイズ</param>
    void ChangeWindowSize<TViewModel>(TViewModel viewModel, WindowSize windowSize)
        where TViewModel : class, IViewModel;

    /// <summary>
    /// 指定したViewModelに関連付けられたWindowのサイズ変更を監視します。
    /// </summary>
    /// <typeparam name="TViewModel">サイズ変更を監視するWindowに関連付けられたViewModelの型</typeparam>
    /// <param name="viewModel">サイズ変更を監視するWindowに関連付けられたViewModel</param>
    /// <returns>Windowのサイズ変更を通知するObservableを返します。</returns>
    Observable<WindowSize> ObserveWindowSizeChanged<TViewModel>(TViewModel viewModel)
        where TViewModel : class, IViewModel;
}
