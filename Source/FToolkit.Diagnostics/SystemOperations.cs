using System.Buffers;
using System.Diagnostics;
using System.Text;
using Cysharp.Diagnostics;
using FToolkit.Diagnostics.Extensions;
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
    /// <exception cref="ArgumentNullException"><paramref name="logger"/>がnullです。</exception>
    public SystemOperations(ILogger<SystemOperations> logger!!)
        => _logger = logger;

    /// <inheritdoc/>
    /// <exception cref="ArgumentNullException"><paramref name="url"/>がnullです。</exception>
    public void OpenInWebBrowser(string url!!)
    {
        OpeningLink(url);

        Process.Start(new ProcessStartInfo()
        {
            FileName = url,
            UseShellExecute = true
        });
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentNullException"><paramref name="bufferWriter"/>または<paramref name="command"/>がnullです。</exception>
    /// <exception cref="ProcessErrorException">終了コードが0以外または標準エラーに出力があります。</exception>
    /// <exception cref="InvalidOperationException">コマンドを実行できません。</exception>
    public async ValueTask<bool> TryStartCommandAsync(
        IBufferWriter<char> bufferWriter!!,
        string command!!,
        string? workingDirectory = null,
        IDictionary<string, string>? environmentVariable = null,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default)
    {
        StartingCommand(command);

        try
        {
            await foreach (var item in ProcessX.StartAsync(command, workingDirectory, environmentVariable, encoding)
                .WithCancellation(cancellationToken)
                .ConfigureAwait(false))
            {
                bufferWriter.WriteLine(item);
            }

            return true;
        }
        catch (ProcessErrorException ex)
        {
            CouldNotStartCommand(command, ex);
        }

        return false;
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentNullException"><paramref name="bufferWriter"/>または<paramref name="fileName"/>がnullです。</exception>
    /// <exception cref="ProcessErrorException">終了コードが0以外または標準エラーに出力があります。</exception>
    /// <exception cref="InvalidOperationException">プロセスを起動できません。</exception>
    public async ValueTask<bool> TryStartProcessAsync(
        IBufferWriter<char> bufferWriter!!,
        string fileName!!,
        string? arguments = null,
        string? workingDirectory = null,
        IDictionary<string, string>? environmentVariable = null,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default)
    {
        StartingProcess(fileName);

        try
        {
            await foreach (var item in ProcessX.StartAsync(fileName, arguments, workingDirectory, environmentVariable, encoding)
                .WithCancellation(cancellationToken)
                .ConfigureAwait(false))
            {
                bufferWriter.WriteLine(item);
            }

            return true;
        }
        catch (ProcessErrorException ex)
        {
            CouldNotStartProcess(fileName, ex);
        }

        return false;
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentNullException"><paramref name="command"/>がnullです。</exception>
    /// <exception cref="ProcessErrorException">終了コードが0以外または標準エラーに出力があります。</exception>
    /// <exception cref="InvalidOperationException">コマンドを起動できません。</exception>
    public async ValueTask TryWaitCommandAsync(
        string command!!,
        string? workingDirectory = null,
        IDictionary<string, string>? environmentVariable = null,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default)
    {
        StartingCommand(command);

        try
        {
            await ProcessX.StartAsync(command, workingDirectory, environmentVariable, encoding)
                .WaitAsync(cancellationToken)
                .ConfigureAwait(false);
        }
        catch (ProcessErrorException ex)
        {
            CouldNotStartCommand(command, ex);
        }
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentNullException"><paramref name="fileName"/>がnullです。</exception>
    /// <exception cref="ProcessErrorException">終了コードが0以外または標準エラーに出力があります。</exception>
    /// <exception cref="InvalidOperationException">プロセスを起動できません。</exception>
    public async ValueTask TryWaitProcessAsync(
        string fileName!!,
        string? arguments = null,
        string? workingDirectory = null,
        IDictionary<string, string>? environmentVariable = null,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default)
    {
        StartingProcess(fileName);

        try
        {
            await ProcessX.StartAsync(fileName, arguments, workingDirectory, environmentVariable, encoding)
                .WaitAsync(cancellationToken)
                .ConfigureAwait(false);
        }
        catch (ProcessErrorException ex)
        {
            CouldNotStartProcess(fileName, ex);
        }
    }

    [LoggerMessage(EventId = 1, Level = LogLevel.Information, Message = "Opening link: {url}")]
    partial void OpeningLink(string url);

    [LoggerMessage(EventId = 100, Level = LogLevel.Information, Message = "Starting command: {command}")]
    partial void StartingCommand(string command);

    [LoggerMessage(EventId = 101, Level = LogLevel.Information, Message = "Starting process: {fileName}")]
    partial void StartingProcess(string fileName);

    [LoggerMessage(EventId = 10000, Level = LogLevel.Warning, Message = "Could not start command: {command}")]
    partial void CouldNotStartCommand(string command, Exception ex);

    [LoggerMessage(EventId = 10001, Level = LogLevel.Warning, Message = "Could not start process: {fileName}")]
    partial void CouldNotStartProcess(string fileName, Exception ex);
}
