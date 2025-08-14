using FToolkit.Options;
using FToolkit.Publishers;

namespace FToolkit;

/// <summary>
/// 設定マネージャーのインスタンスを生成するためのインターフェイスです。
/// </summary>
/// <typeparam name="TSelf">自身の型</typeparam>
/// <typeparam name="TSettings">設定の型</typeparam>
/// <typeparam name="TArgument">設定マネージャーに渡す引数の型</typeparam>
public interface ISettingsManagerConstructible<out TSelf, in TSettings, in TArgument> : IConstructible<TSelf, IReloadableOptions<TSettings>, IPublisher, TArgument>;
