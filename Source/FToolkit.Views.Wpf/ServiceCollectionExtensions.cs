using Microsoft.Extensions.DependencyInjection;

namespace FToolkit.Views.Wpf;

/// <summary>
/// WPFに関連するクラスを<see cref="IServiceCollection"/>に追加する拡張メソッドです。
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// WPFに関連するオブジェクトを<see cref="IServiceCollection"/>に追加します。
    /// </summary>
    /// <param name="services">追加する対象の<see cref="IServiceCollection"/></param>
    public static void AddWpf(this IServiceCollection services)
        => services.AddSingleton<IWindowService, WpfWindowService>();
}
