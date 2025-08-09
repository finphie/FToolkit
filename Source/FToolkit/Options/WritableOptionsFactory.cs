using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization.Metadata;
using FToolkit.IO;
using FToolkit.Objects;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FToolkit.Options;

/// <summary>
/// <see cref="WritableOptions{T}"/>のインスタンスを作成するためのファクトリクラスです。
/// </summary>
public sealed class WritableOptionsFactory
{
    readonly IServiceProvider _provider;

    /// <summary>
    /// <see cref="WritableOptionsFactory"/>クラスの新しいインスタンスを初期化します。
    /// </summary>
    /// <param name="provider">依存関係解決に使用するサービスプロバイダー</param>
    public WritableOptionsFactory(IServiceProvider provider)
    {
        ArgumentNullException.ThrowIfNull(provider);
        _provider = provider;
    }

    /// <summary>
    /// <see cref="WritableOptions{T}"/>クラスの新しいインスタンスを作成します。
    /// </summary>
    /// <typeparam name="T">オプションの種類</typeparam>
    /// <param name="filePath">ファイルパス</param>
    /// <param name="jsonTypeInfo">JSONシリアル化のメタデータ</param>
    /// <returns><see cref="WritableOptions{T}"/>クラスのインスタンスを返します。</returns>
    public IWritableOptions<T> Create<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)] T>(FilePath filePath, JsonTypeInfo<T> jsonTypeInfo)
        where T : class, IEquatable<T>
    {
        var logger = _provider.GetRequiredService<ILogger<WritableOptions<T>>>();
        var configuration = _provider.GetRequiredService<IConfiguration>();
        var options = _provider.GetRequiredService<IOptionsMonitor<T>>();
        var fileOperations = _provider.GetRequiredService<IFileOperations>();

        return new WritableOptions<T>(logger, configuration, options, fileOperations, filePath, jsonTypeInfo);
    }
}
