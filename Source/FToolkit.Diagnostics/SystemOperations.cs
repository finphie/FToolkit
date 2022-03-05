using System.Buffers;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Cysharp.Diagnostics;
using Microsoft.Extensions.Logging;

namespace FToolkit.Diagnostics;

/// <summary>
/// システムに関する操作を行うクラスです。
/// </summary>
public sealed partial class SystemOperations : ISystemOperations
{
    readonly ILogger _logger;

    /// <summary>
    /// <see cref="SystemOperations"/>クラスの新しいインスタンスを初期化します。
    /// </summary>
    /// <param name="logger">ロガー</param>
    public SystemOperations(ILogger<SystemOperations> logger)
    {
        ArgumentNullException.ThrowIfNull(logger);
        _logger = logger;
    }

    /// <inheritdoc/>
    public void OpenInWebBrowser(string url)
    {
        ArgumentNullException.ThrowIfNull(url);
        OpeningLink(url);

        Process.Start(new ProcessStartInfo()
        {
            FileName = url,
            UseShellExecute = true
        });
    }

    /// <inheritdoc/>
    public async ValueTask<bool> TryStartProcessAsync(IBufferWriter<char> bufferWriter, string fileName, string? arguments = null, IDictionary<string, string>? environmentVariable = null)
    {
        ArgumentNullException.ThrowIfNull(bufferWriter);
        ArgumentNullException.ThrowIfNull(fileName);

        StartingProcess(fileName);

        try
        {
            await foreach (var item in ProcessX.StartAsync(fileName, arguments: arguments, environmentVariable: environmentVariable).ConfigureAwait(false))
            {
                WriteLine(bufferWriter, item);
            }

            return true;
        }
        catch (ProcessErrorException ex)
        {
            CouldNotStartProcess(fileName, ex);
        }

        return false;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static void WriteLine(IBufferWriter<char> bufferWriter, string value)
        {
            bufferWriter.Write(value);
            bufferWriter.Write("\n");
        }
    }

    [LoggerMessage(EventId = 1, Level = LogLevel.Information, Message = "Opening link: {url}")]
    partial void OpeningLink(string url);

    [LoggerMessage(EventId = 2, Level = LogLevel.Information, Message = "Starting process: {fileName}")]
    partial void StartingProcess(string fileName);

    [LoggerMessage(EventId = 5001, Level = LogLevel.Warning, Message = "Could not start process: {fileName}")]
    partial void CouldNotStartProcess(string fileName, Exception ex);
}
