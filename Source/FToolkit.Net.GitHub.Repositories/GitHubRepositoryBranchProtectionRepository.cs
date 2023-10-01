using FToolkit.Net.GitHub.Client;
using FToolkit.Net.GitHub.Repositories.Entities;
using Microsoft.Extensions.Logging;

namespace FToolkit.Net.GitHub.Repositories;

/// <summary>
/// GitHubブランチ保護設定に関する操作を行うクラスです。
/// </summary>
public sealed partial class GitHubRepositoryBranchProtectionRepository : IGitHubRepositoryBranchProtectionRepository
{
    readonly ILogger<GitHubRepositoryBranchProtectionRepository> _logger;
    readonly IGitHubClient _gitHubClient;

    /// <summary>
    /// <see cref="GitHubRepositoryBranchProtectionRepository"/>クラスの新しいインスタンスを初期化します。
    /// </summary>
    /// <param name="logger">ロガー</param>
    /// <param name="gitHubClient">GitHubクライアント</param>
    /// <exception cref="ArgumentNullException"><paramref name="logger"/>または<paramref name="gitHubClient"/>がnullです。</exception>
    public GitHubRepositoryBranchProtectionRepository(ILogger<GitHubRepositoryBranchProtectionRepository> logger, IGitHubClient gitHubClient)
    {
        ArgumentNullException.ThrowIfNull(logger);
        ArgumentNullException.ThrowIfNull(gitHubClient);

        _logger = logger;
        _gitHubClient = gitHubClient;
    }

    /// <inheritdoc/>
    public Task UpdateAsync(BranchRequest request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);

        Updating();

        return _gitHubClient.UpdateBranchProtectionAsync(request.Owner, request.Name, request.Branch, request.Settings.ToEntity(), cancellationToken);
    }

    /// <inheritdoc/>
    public Task DeleteAsync(BranchIdentifierRequest request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);

        Deleting();

        return _gitHubClient.DeleteBranchProtectionAsync(request.Owner, request.Name, request.Branch, cancellationToken);
    }

    [LoggerMessage(Level = LogLevel.Debug, Message = "Updating branch protection settings.")]
    partial void Updating();

    [LoggerMessage(Level = LogLevel.Debug, Message = "Deleting branch protection settings.")]
    partial void Deleting();
}
