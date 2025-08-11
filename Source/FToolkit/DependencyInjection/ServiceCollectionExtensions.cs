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
    /// <typeparam name="TApplicationInfo">アプリケーション情報の型</typeparam>
    /// <param name="services">追加する対象の<see cref="IServiceCollection"/></param>
    public static void AddFToolkit<[DynamicallyAccessedMembers(PublicConstructors)] TApplicationInfo>(this IServiceCollection services)
        where TApplicationInfo : ApplicationInfoBase
    {
        services.AddSingleton<TApplicationInfo>();
        services.AddSingleton<ApplicationInfoBase>(static x => x.GetRequiredService<TApplicationInfo>());

        services.AddSingleton<IViewLocator, ViewLocator>();
        services.AddSingleton<IPublisher, Publisher>();

        services.AddSingleton<IFileOperations, FileOperations>();
        services.AddSingleton<IDirectoryOperations, DirectoryOperations>();
    }

    /// <summary>
    /// 設定関連のオブジェクトを<see cref="IServiceCollection"/>に追加します。
    /// </summary>
    /// <typeparam name="TApplicationSettings">アプリケーション設定の型</typeparam>
    /// <typeparam name="TSettingsManager">設定マネージャーインターフェイスの型</typeparam>
    /// <typeparam name="TImplementationSettingsManager">設定マネージャーの型</typeparam>
    /// <param name="services">追加する対象の<see cref="IServiceCollection"/></param>
    /// <param name="settingsJsonTypeInfo">設定に関するJSONシリアル化のメタデータ</param>
    public static void AddFToolkitSettings<[DynamicallyAccessedMembers(PublicParameterlessConstructor)] TApplicationSettings, TSettingsManager, [DynamicallyAccessedMembers(PublicConstructors)] TImplementationSettingsManager>(this IServiceCollection services, JsonTypeInfo<TApplicationSettings> settingsJsonTypeInfo)
        where TApplicationSettings : ApplicationSettingsBase, IEquatable<TApplicationSettings>
        where TSettingsManager : class, ISettingsManagerBase<TApplicationSettings>
        where TImplementationSettingsManager : class, TSettingsManager
    {
        services.AddSingleton<IReloadableOptions<TApplicationSettings>, ReloadableOptions<TApplicationSettings>>();
        services.AddWritableOptions(settingsJsonTypeInfo);
        services.AddSingleton<TSettingsManager, TImplementationSettingsManager>();
        services.AddSingleton<ISettingsManagerBase<ApplicationSettingsBase>>(static x => x.GetRequiredService<TSettingsManager>());

        services.AddSubscribers<TApplicationSettings>();
    }

    /// <summary>
    /// ViewとViewModelを<see cref="IServiceCollection"/>に追加します。
    /// </summary>
    /// <typeparam name="TView">View</typeparam>
    /// <typeparam name="TViewModel">ViewModel</typeparam>
    /// <param name="services">追加する対象の<see cref="IServiceCollection"/></param>
    public static void AddViewAndViewModel<[DynamicallyAccessedMembers(PublicConstructors)] TView, [DynamicallyAccessedMembers(PublicConstructors)] TViewModel>(this IServiceCollection services)
        where TView : class, IViewFor<TViewModel>
        where TViewModel : class, ITransientViewModel
    {
        services.AddTransient<IViewFor<TViewModel>, TView>();
        services.AddViewModel<TViewModel>();
    }

    /// <summary>
    /// ViewModelを<see cref="IServiceCollection"/>に追加します。
    /// </summary>
    /// <typeparam name="TViewModel">ViewModel</typeparam>
    /// <param name="services">追加する対象の<see cref="IServiceCollection"/></param>
    public static void AddViewModel<[DynamicallyAccessedMembers(PublicConstructors)] TViewModel>(this IServiceCollection services)
        where TViewModel : class, ITransientViewModel
        => services.AddTransient<TViewModel>();

    /// <summary>
    /// MainViewModelを<see cref="IServiceCollection"/>に追加します。
    /// </summary>
    /// <typeparam name="TViewModel">ViewModel</typeparam>
    /// <param name="services">追加する対象の<see cref="IServiceCollection"/></param>
    public static void AddMainViewModel<[DynamicallyAccessedMembers(PublicConstructors)] TViewModel>(this IServiceCollection services)
        where TViewModel : class, IMainViewModel
        => services.AddSingleton<TViewModel>();

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

    static void AddSubscribers<TApplicationSettings>(this IServiceCollection services)
        where TApplicationSettings : ApplicationSettingsBase
    {
        services.AddActivatedSingleton<UpdateApplicationsSettingsSubscriber<TApplicationSettings>>();
        services.AddActivatedSingleton<ApplyThemeRequestSubscriber>();
    }
}
