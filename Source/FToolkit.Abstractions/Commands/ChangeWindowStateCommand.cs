using FToolkit.Objects;
using FToolkit.ViewModels;

namespace FToolkit.Commands;

/// <summary>
/// Windowの状態を変更するコマンドです。
/// </summary>
/// <param name="ViewModel">ViewModel</param>
/// <param name="State">Windowの状態</param>
public sealed record ChangeWindowStateCommand(IViewModel ViewModel, WindowState State);
