using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization.Metadata;
using FToolkit.Managers;
using FToolkit.Objects;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using static System.Diagnostics.CodeAnalysis.DynamicallyAccessedMemberTypes;

namespace FToolkit.DependencyInjection;

/// <summary>
/// <see cref="IHostApplicationBuilder"/>を実装したオブジェクトに対する拡張メソッドです。
/// </summary>
public static class HostApplicationBuilderExtensions
{
    /// <summary>
    /// <see cref="FToolkit"/>に関連するオブジェクトを<see cref="IHostApplicationBuilder"/>に追加します。
    /// </summary>
    /// <typeparam name="TApplicationInfo">アプリケーション情報の型</typeparam>
    /// <typeparam name="TApplicationSettings">アプリケーション設定の型</typeparam>
    /// <typeparam name="TApplicationSettingsManager">アプリケーション設定マネージャーの型</typeparam>
    /// <param name="builder">追加する対象の<see cref="IHostApplicationBuilder"/></param>
    /// <param name="applicationSettingsJsonTypeInfo">アプリケーション設定に関するJSONシリアル化のメタデータ</param>
    /// <exception cref="ArgumentNullException"><paramref name="applicationSettingsJsonTypeInfo"/>が<see langword="null"/>です。</exception>
    public static void AddFToolkit<[DynamicallyAccessedMembers(PublicConstructors)] TApplicationInfo, [DynamicallyAccessedMembers(PublicParameterlessConstructor)] TApplicationSettings, [DynamicallyAccessedMembers(PublicConstructors)] TApplicationSettingsManager>(this IHostApplicationBuilder builder, JsonTypeInfo<TApplicationSettings> applicationSettingsJsonTypeInfo)
        where TApplicationInfo : ApplicationInfoBase
        where TApplicationSettings : ApplicationSettingsBase
        where TApplicationSettingsManager : ApplicationSettingsManagerBase<TApplicationSettings>
    {
        ArgumentNullException.ThrowIfNull(applicationSettingsJsonTypeInfo);

        builder.Services.AddFToolkit<TApplicationInfo, TApplicationSettings, TApplicationSettingsManager>(applicationSettingsJsonTypeInfo);
        builder.Configuration.AddJsonFile(Constants.ApplicationSettingsFilePath.AsPrimitive(), true);
    }
}
