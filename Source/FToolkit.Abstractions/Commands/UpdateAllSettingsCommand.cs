using FToolkit.ViewModels;

namespace FToolkit.Commands;

/// <summary>
/// すべての設定を更新するコマンドです。
/// </summary>
/// <param name="ViewModel">設定を更新する対象の <see cref="IViewModel"/>を実装したオブジェクト</param>
public sealed record UpdateAllSettingsCommand(IViewModel ViewModel);
