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
    /// <typeparam name="TApplicationSettings">アプリケーション設定の型</typeparam>
    /// <typeparam name="TApplicationSettingsManager">アプリケーション設定マネージャーの型</typeparam>
    /// <param name="services">追加する対象の<see cref="IServiceCollection"/></param>
    /// <param name="applicationSettingsJsonTypeInfo">アプリケーション設定に関するJSONシリアル化のメタデータ</param>
    /// <exception cref="ArgumentNullException"><paramref name="applicationSettingsJsonTypeInfo"/>がnullです。</exception>
    public static void AddFToolkit<[DynamicallyAccessedMembers(PublicConstructors)] TApplicationInfo, [DynamicallyAccessedMembers(PublicParameterlessConstructor)] TApplicationSettings, [DynamicallyAccessedMembers(PublicConstructors)] TApplicationSettingsManager>(this IServiceCollection services, JsonTypeInfo<TApplicationSettings> applicationSettingsJsonTypeInfo)
        where TApplicationInfo : ApplicationInfoBase
        where TApplicationSettings : ApplicationSettingsBase
        where TApplicationSettingsManager : ApplicationSettingsManagerBase<TApplicationSettings>
    {
        ArgumentNullException.ThrowIfNull(applicationSettingsJsonTypeInfo);

        services.AddSingleton<TApplicationInfo>();
        services.AddSingleton<ApplicationInfoBase>(static x => x.GetRequiredService<TApplicationInfo>());

        services.AddOptions(ApplicationSettingsFilePath, applicationSettingsJsonTypeInfo);
        services.AddSingleton<IApplicationSettingsManagerBase, TApplicationSettingsManager>();
        services.AddActivatedSingleton<UpdateApplicationsSettingsSubscriber<TApplicationSettings>>();

        services.AddSingleton<IViewLocator, ViewLocator>();
        services.AddSingleton<IPublisher, Publisher>();

        services.AddSingleton<IFileOperations, FileOperations>();
        services.AddSingleton<IDirectoryOperations, DirectoryOperations>();

        services.AddSubscribers();
    }

    /// <summary>
    /// 設定関連のオブジェクトを<see cref="IServiceCollection"/>に追加します。
    /// </summary>
    /// <typeparam name="TSettings">設定の型</typeparam>
    /// <typeparam name="TSettingsManager">設定マネージャーの型</typeparam>
    /// <param name="services">追加する対象の<see cref="IServiceCollection"/></param>
    /// <param name="settingsFilePath">設定ファイルのパス</param>
    /// <param name="settingsJsonTypeInfo">設定に関するJSONシリアル化のメタデータ</param>
    /// <exception cref="ArgumentNullException"><paramref name="settingsJsonTypeInfo"/>がnullです。</exception>
    public static void AddSettings<[DynamicallyAccessedMembers(PublicParameterlessConstructor)] TSettings, [DynamicallyAccessedMembers(PublicConstructors)] TSettingsManager>(this IServiceCollection services, FilePath settingsFilePath, JsonTypeInfo<TSettings> settingsJsonTypeInfo)
        where TSettings : ISettings
        where TSettingsManager : SettingsManagerBase<TSettings>
    {
        ArgumentNullException.ThrowIfNull(settingsJsonTypeInfo);

        services.AddOptions(settingsFilePath, settingsJsonTypeInfo);
        services.AddSettingsManager<TSettings, TSettingsManager>();
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
    {
        services.AddSingleton<TViewModel>();
        services.AddSingleton<IMainViewModel>(static x => x.GetRequiredService<TViewModel>());
    }

    static void AddOptions<[DynamicallyAccessedMembers(PublicParameterlessConstructor)] TSettings>(this IServiceCollection services, FilePath settingsFilePath, JsonTypeInfo<TSettings> jsonTypeInfo)
        where TSettings : ISettings
    {
        services.AddSingleton<IReloadableOptions<TSettings>, ReloadableOptions<TSettings>>();
        services.AddWritableOptions(settingsFilePath, jsonTypeInfo);
    }

    static void AddWritableOptions<[DynamicallyAccessedMembers(PublicParameterlessConstructor)] TSettings>(this IServiceCollection services, FilePath settingsFilePath, JsonTypeInfo<TSettings> jsonTypeInfo)
        where TSettings : ISettings
    {
        services.AddSingleton<WritableOptionsFactory>();
        services.AddSingleton(x =>
        {
            var factory = x.GetRequiredService<WritableOptionsFactory>();
            return factory.Create(settingsFilePath, jsonTypeInfo);
        });
    }

    static void AddSettingsManager<TSettings, [DynamicallyAccessedMembers(PublicConstructors)] TSettingsManager>(this IServiceCollection services)
        where TSettings : ISettings
        where TSettingsManager : class, ISettingsManagerBase
    {
        services.AddSingleton<ISettingsManagerBase, TSettingsManager>();
        services.AddActivatedSingleton<UpdateApplicationsSettingsSubscriber<TSettings>>();
    }

    static void AddSubscribers(this IServiceCollection services)
        => services.AddActivatedSingleton<ChangeApplicationThemeSubscriber>();
}
