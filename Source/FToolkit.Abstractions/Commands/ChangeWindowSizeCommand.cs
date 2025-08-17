using FToolkit.Objects;
using FToolkit.ViewModels;

namespace FToolkit.Commands;

/// <summary>
/// Windowサイズを変更するコマンドです。
/// </summary>
/// <param name="ViewModel">ViewModel</param>
/// <param name="Size">Windowサイズ</param>
public sealed record ChangeWindowSizeCommand(IViewModel ViewModel, WindowSize Size);
