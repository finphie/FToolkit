﻿using System.Buffers;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
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
    const int SuccessExitCode = 0;

    readonly ILogger<SystemOperations> _logger;

    /// <summary>
    /// <see cref="SystemOperations"/>クラスの新しいインスタンスを初期化します。
    /// </summary>
    /// <param name="logger">ロガー</param>
    /// <exception cref="ArgumentNullException"><paramref name="logger"/>がnullです。</exception>
    public SystemOperations(ILogger<SystemOperations> logger)
    {
        ArgumentNullException.ThrowIfNull(logger);
        _logger = logger;
    }

    /// <inheritdoc/>
    [SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP004:Don't ignore created IDisposable", Justification = "URL")]
    public void OpenInWebBrowser(string url)
    {
        ArgumentNullException.ThrowIfNull(url);

        OpeningLink(url);

        Process.Start(new ProcessStartInfo
        {
            FileName = url,
            UseShellExecute = true
        });
    }

    /// <inheritdoc/>
    public void OpenInWebBrowser(Uri url)
    {
        ArgumentNullException.ThrowIfNull(url);
        OpenInWebBrowser(url.AbsolutePath);
    }

    /// <inheritdoc/>
    public async ValueTask<int> WaitCommandAsync(
        IBufferWriter<char> bufferWriter,
        string command,
        string? workingDirectory = null,
        IDictionary<string, string>? environmentVariable = null,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(bufferWriter);
        ArgumentNullException.ThrowIfNull(command);

        StartingCommand(command);

        try
        {
            await foreach (var item in ProcessX.StartAsync(command, workingDirectory, environmentVariable, encoding)
                .WithCancellation(cancellationToken)
                .ConfigureAwait(false))
            {
                bufferWriter.WriteLine(item);
            }
        }
        catch (ProcessErrorException ex)
        {
            CouldNotStartCommand(command, ex);
            return ex.ExitCode;
        }
        catch (Exception ex)
        {
            CouldNotStartCommand(command, ex);
            throw;
        }

        return SuccessExitCode;
    }

    /// <inheritdoc/>
    public async ValueTask<int> WaitCommandAsync(
        string command,
        string? workingDirectory = null,
        IDictionary<string, string>? environmentVariable = null,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(command);

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
            return ex.ExitCode;
        }
        catch (Exception ex)
        {
            CouldNotStartCommand(command, ex);
            throw;
        }

        return SuccessExitCode;
    }

    /// <inheritdoc/>
    public async ValueTask<int> WaitProcessAsync(
        IBufferWriter<char> bufferWriter,
        string fileName,
        string? arguments = null,
        string? workingDirectory = null,
        IDictionary<string, string>? environmentVariable = null,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(bufferWriter);
        ArgumentNullException.ThrowIfNull(fileName);

        StartingProcess(fileName);

        try
        {
            await foreach (var item in ProcessX.StartAsync(fileName, arguments, workingDirectory, environmentVariable, encoding)
                .WithCancellation(cancellationToken)
                .ConfigureAwait(false))
            {
                bufferWriter.WriteLine(item);
            }
        }
        catch (ProcessErrorException ex)
        {
            CouldNotStartProcess(fileName, ex);
            return ex.ExitCode;
        }
        catch (Exception ex)
        {
            CouldNotStartProcess(fileName, ex);
            throw;
        }

        return SuccessExitCode;
    }

    /// <inheritdoc/>
    public async ValueTask<int> WaitProcessAsync(
        string fileName,
        string? arguments = null,
        string? workingDirectory = null,
        IDictionary<string, string>? environmentVariable = null,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(fileName);

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
            return ex.ExitCode;
        }
        catch (Exception ex)
        {
            CouldNotStartProcess(fileName, ex);
            throw;
        }

        return SuccessExitCode;
    }

    [LoggerMessage(Level = LogLevel.Information, Message = "Opening link: {url}")]
    partial void OpeningLink(string url);

    [LoggerMessage(Level = LogLevel.Information, Message = "Starting command: {command}")]
    partial void StartingCommand(string command);

    [LoggerMessage(Level = LogLevel.Information, Message = "Starting process: {fileName}")]
    partial void StartingProcess(string fileName);

    [LoggerMessage(Level = LogLevel.Warning, Message = "Could not start command: {command}")]
    partial void CouldNotStartCommand(string command, Exception ex);

    [LoggerMessage(Level = LogLevel.Warning, Message = "Could not start process: {fileName}")]
    partial void CouldNotStartProcess(string fileName, Exception ex);
}
