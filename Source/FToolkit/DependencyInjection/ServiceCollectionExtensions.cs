using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization.Metadata;
using FToolkit.IO;
using FToolkit.Managers;
using FToolkit.Objects;
using FToolkit.Options;
using FToolkit.Publishers;
using FToolkit.Subscribers;
using FToolkit.ViewModels;
using FToolkit.Views;
using Microsoft.Extensions.DependencyInjection;
using static System.Diagnostics.CodeAnalysis.DynamicallyAccessedMemberTypes;

namespace FToolkit.DependencyInjection;

/// <summary>
/// FToolkitに関連するクラスを<see cref="IServiceCollection"/>に追加する拡張メソッドです。
/// </summary>
public static class ServiceCollectionExtensions
{
    static readonly FilePath ApplicationSettingsFilePath = new("appsettings.json");

    /// <summary>
    /// <see cref="FToolkit"/>に関連するオブジェクトを<see cref="IServiceCollection"/>に追加します。
    /// </summary>
    /// <typeparam name="TSettings">アプリケーション設定の型</typeparam>
    /// <typeparam name="TSettingsManager">設定マネージャーインターフェイスの型</typeparam>
    /// <typeparam name="TImplementationSettingsManager">設定マネージャーの型</typeparam>
    /// <param name="services">追加する対象の<see cref="IServiceCollection"/></param>
    /// <param name="settingsJsonTypeInfo">設定に関するJSONシリアル化のメタデータ</param>
    public static void AddFToolkit<[DynamicallyAccessedMembers(PublicParameterlessConstructor)] TSettings, TSettingsManager, [DynamicallyAccessedMembers(PublicConstructors)] TImplementationSettingsManager>(this IServiceCollection services, JsonTypeInfo<TSettings> settingsJsonTypeInfo)
        where TSettings : ApplicationSettingsBase, IEquatable<TSettings>
        where TSettingsManager : class, ISettingsManagerBase<TSettings>
        where TImplementationSettingsManager : class, TSettingsManager
    {
        services.AddSingleton<IReloadableOptions<TSettings>, ReloadableOptions<TSettings>>();
        services.AddWritableOptions(settingsJsonTypeInfo);
        services.AddSingleton<TSettingsManager, TImplementationSettingsManager>();

        services.AddSingleton<IPublisher, Publisher>();
        services.AddView<TSettings>();

        services.AddSingleton<IFileOperations, FileOperations>();
        services.AddSingleton<IDirectoryOperations, DirectoryOperations>();
    }

    /// <summary>
    /// ViewとViewModelを<see cref="IServiceCollection"/>に追加します。
    /// </summary>
    /// <typeparam name="TView">View</typeparam>
    /// <typeparam name="TViewModel">ViewModel</typeparam>
    /// <param name="services">追加する対象の<see cref="IServiceCollection"/></param>
    public static void AddViewAndViewModel<[DynamicallyAccessedMembers(PublicConstructors)] TView, [DynamicallyAccessedMembers(PublicConstructors)] TViewModel>(this IServiceCollection services)
        where TView : class, IViewFor<TViewModel>
        where TViewModel : class, IViewModel
    {
        services.AddTransient<IViewFor<TViewModel>, TView>();
        services.AddTransient<TViewModel>();
    }

    static void AddWritableOptions<[DynamicallyAccessedMembers(PublicParameterlessConstructor)] T>(this IServiceCollection services, JsonTypeInfo<T> jsonTypeInfo)
        where T : ApplicationSettingsBase, IEquatable<T>
    {
        services.AddSingleton<WritableOptionsFactory>();
        services.AddSingleton(x =>
        {
            var factory = x.GetRequiredService<WritableOptionsFactory>();
            return factory.Create(ApplicationSettingsFilePath, jsonTypeInfo);
        });
    }

    static void AddView<T>(this IServiceCollection services)
        where T : ApplicationSettingsBase
    {
        services.AddSingleton<IViewLocator, ViewLocator>();

        services.AddActivatedSingleton<ApplyThemeRequestSubscriber>();
        services.AddActivatedSingleton<UpdateApplicationsSettingsSubscriber<T>>();
    }
}
