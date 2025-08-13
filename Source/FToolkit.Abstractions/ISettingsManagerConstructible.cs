using FToolkit.Options;
using FToolkit.Publishers;
using FToolkit.ViewModels;

namespace FToolkit;

/// <summary>
/// 設定マネージャーのインスタンスを生成するためのインターフェイスです。
/// </summary>
/// <typeparam name="TSelf">自身の型</typeparam>
/// <typeparam name="TSettings">設定の型</typeparam>
public interface ISettingsManagerConstructible<out TSelf, in TSettings> : IConstructible<TSelf, IReloadableOptions<TSettings>, IPublisher, IViewModel>;
