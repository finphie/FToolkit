using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using CommunityToolkit.HighPerformance.Buffers;
using FToolkit.IO;
using FToolkit.Objects;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FToolkit.Options;

/// <summary>
/// オプション値を更新するクラスです。
/// </summary>
/// <typeparam name="T">オプションの種類</typeparam>
public sealed partial class WritableOptions<T> : IWritableOptions<T>
    where T : class
{
    readonly ILogger<WritableOptions<T>> _logger;
    readonly IOptionsMonitor<T> _options;
    readonly IFileOperations _fileOperations;
    readonly FileConfigurationProvider[] _fileProviders;

    readonly FilePath _filePath;
    readonly JsonTypeInfo<T> _jsonTypeInfo;

    /// <summary>
    /// <see cref="WritableOptions{T}"/>クラスの新しいインスタンスを初期化します。
    /// </summary>
    /// <param name="logger">ログ記録のためのオブジェクト</param>
    /// <param name="configuration">構成情報を提供するオブジェクト</param>
    /// <param name="options">オプション値の取得を行うオブジェクト</param>
    /// <param name="fileOperations">ファイル操作を行うオブジェクト</param>
    /// <param name="filePath">出力先ファイルパス</param>
    /// <param name="jsonTypeInfo">JSONシリアル化のメタデータ</param>
    public WritableOptions(ILogger<WritableOptions<T>> logger, IConfiguration configuration, IOptionsMonitor<T> options, IFileOperations fileOperations, FilePath filePath, JsonTypeInfo<T> jsonTypeInfo)
    {
        ArgumentNullException.ThrowIfNull(logger);
        ArgumentNullException.ThrowIfNull(configuration);
        ArgumentNullException.ThrowIfNull(options);
        ArgumentNullException.ThrowIfNull(fileOperations);
        ArgumentNullException.ThrowIfNull(jsonTypeInfo);

        _logger = logger;
        _options = options;
        _fileOperations = fileOperations;

        var configurationRoot = (IConfigurationRoot)configuration;
        _fileProviders = [.. configurationRoot.Providers.OfType<FileConfigurationProvider>()];

        _filePath = filePath;
        _jsonTypeInfo = jsonTypeInfo;
    }

    /// <inheritdoc/>
    public async ValueTask UpdateAsync(Func<T, T> applyChanges, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(applyChanges);

        var value = applyChanges(_options.CurrentValue);

        if (value == _options.CurrentValue)
        {
            LogNoChangesApplied();
            return;
        }

        using var bufferWriter = new ArrayPoolBufferWriter<byte>();
        var writer = new Utf8JsonWriter(bufferWriter);

        await using (writer.ConfigureAwait(false))
        {
            JsonSerializer.Serialize(writer, value, _jsonTypeInfo);
        }

        await WritableOptionsLock.ReadWriteLock.WaitAsync(cancellationToken).ConfigureAwait(false);

        try
        {
            await _fileOperations.SaveAsync(_filePath, bufferWriter.WrittenMemory, cancellationToken).ConfigureAwait(false);

            foreach (var fileProvider in _fileProviders)
            {
                LogReloadingConfigurationProvider(fileProvider.Source.Path);
                fileProvider.Load();
            }
        }
        finally
        {
            WritableOptionsLock.ReadWriteLock.Release();
        }
    }

    [LoggerMessage(Level = LogLevel.Debug, Message = "No changes were applied to the options.")]
    partial void LogNoChangesApplied();

    [LoggerMessage(Level = LogLevel.Debug, Message = "Reloading configuration provider: {filePath}")]
    partial void LogReloadingConfigurationProvider(string? filePath);

    static class WritableOptionsLock
    {
        internal static readonly SemaphoreSlim ReadWriteLock = new(1);
    }
}
