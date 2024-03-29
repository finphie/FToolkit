﻿using System.Net;
using System.Net.Http.Json;
using FToolkit.Net.GitHub.Client.Entities;
using Microsoft.Extensions.Logging;

namespace FToolkit.Net.GitHub.Client;

/// <summary>
/// GitHub APIのクライアント。
/// </summary>
public sealed partial class GitHubClient : IGitHubClient
{
    readonly ILogger<GitHubClient> _logger;
    readonly HttpClient _client;

    /// <summary>
    /// <see cref="GitHubClient"/>クラスの新しいインスタンスを初期化します。
    /// </summary>
    /// <param name="logger">ロガー</param>
    /// <param name="client">HTTPクライアント</param>
    /// <exception cref="ArgumentNullException"><paramref name="logger"/>または<paramref name="client"/>がnullです。</exception>
    public GitHubClient(ILogger<GitHubClient> logger, HttpClient client)
    {
        ArgumentNullException.ThrowIfNull(logger);
        ArgumentNullException.ThrowIfNull(client);

        _logger = logger;
        _client = client;
    }

    /// <inheritdoc/>
    public async Task UpdateRepositoryAsync(string owner, string name, GitHubRepository entity, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(owner);
        ArgumentException.ThrowIfNullOrEmpty(name);
        ArgumentNullException.ThrowIfNull(entity);

        UpdatingRepositorySettings(entity);

        var response = await _client.PatchAsJsonAsync(new Uri($"/repos/{owner}/{name}", UriKind.Relative), entity, JsonContext.Default.GitHubRepository, cancellationToken)
            .ConfigureAwait(false);
        response.EnsureSuccessStatusCode();
    }

    /// <inheritdoc/>
    public async Task UpdateBranchProtectionAsync(string owner, string name, string branch, GitHubBranchProtection entity, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(owner);
        ArgumentException.ThrowIfNullOrEmpty(name);
        ArgumentException.ThrowIfNullOrEmpty(branch);
        ArgumentNullException.ThrowIfNull(entity);

        UpdatingBranchProtectionSettings(entity);

        var response = await _client.PutAsJsonAsync(new Uri($"/repos/{owner}/{name}/branches/{branch}/protection", UriKind.Relative), entity, JsonContext.Default.GitHubBranchProtection, cancellationToken)
            .ConfigureAwait(false);
        response.EnsureSuccessStatusCode();
    }

    /// <inheritdoc/>
    public async Task DeleteBranchProtectionAsync(string owner, string name, string branch, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(owner);
        ArgumentException.ThrowIfNullOrEmpty(name);
        ArgumentException.ThrowIfNullOrEmpty(branch);

        DeletingBranchProtectionSettings();

        var response = await _client.DeleteAsync(new Uri($"/repos/{owner}/{name}/branches/{branch}/protection", UriKind.Relative), cancellationToken)
            .ConfigureAwait(false);

        if (response.StatusCode == HttpStatusCode.NoContent)
        {
            DeletingBranchProtectionSettingsNoContent(owner, name, branch);
            return;
        }

        // 指定されたブランチ名の保護が存在しない場合
        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            DeletingBranchProtectionSettingsNotFound(owner, name, branch);
            return;
        }

        response.EnsureSuccessStatusCode();
    }

    [LoggerMessage(Level = LogLevel.Information, Message = "Updating repository settings. {entity}")]
    partial void UpdatingRepositorySettings(GitHubRepository entity);

    [LoggerMessage(Level = LogLevel.Information, Message = "Updating branch protection settings. {entity}")]
    partial void UpdatingBranchProtectionSettings(GitHubBranchProtection entity);

    [LoggerMessage(Level = LogLevel.Information, Message = "Deleting branch protection settings.")]
    partial void DeletingBranchProtectionSettings();

    [LoggerMessage(Level = LogLevel.Information, Message = "No content: {owner}/{name}, {branch}")]
    partial void DeletingBranchProtectionSettingsNoContent(string owner, string name, string branch);

    [LoggerMessage(Level = LogLevel.Information, Message = "Not found: {owner}/{name}, {branch}")]
    partial void DeletingBranchProtectionSettingsNotFound(string owner, string name, string branch);
}
