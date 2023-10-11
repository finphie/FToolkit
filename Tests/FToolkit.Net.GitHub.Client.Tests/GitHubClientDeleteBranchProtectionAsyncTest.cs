using System.Net;
using Microsoft.Extensions.Logging.Abstractions;
using RichardSzalay.MockHttp;
using Xunit;

namespace FToolkit.Net.GitHub.Client.Tests;

public sealed class GitHubClientDeleteBranchProtectionAsyncTest
{
    const string Url = $"/repos/{Owner}/{Name}/branches/{Branch}/protection";

    const string Owner = "finphie";
    const string Name = "test";
    const string Branch = "main";

    static readonly Uri BaseAddress = new("http://localhost");

    [Fact]
    public async Task 存在するブランチ名_正常終了()
    {
        using var handler = new MockHttpMessageHandler();

        handler.Expect(HttpMethod.Delete, Url)
            .Respond(HttpStatusCode.OK);

        var httpClient = handler.ToHttpClient();
        httpClient.BaseAddress = BaseAddress;

        var client = new GitHubClient(NullLogger<GitHubClient>.Instance, httpClient);

        await client.DeleteBranchProtectionAsync(Owner, Name, Branch);
    }

    [Fact]
    public async Task 存在しないブランチ保護_正常終了()
    {
        using var handler = new MockHttpMessageHandler();

        handler.Expect(HttpMethod.Delete, Url)
            .Respond(HttpStatusCode.NotFound);

        var httpClient = handler.ToHttpClient();
        httpClient.BaseAddress = BaseAddress;

        var client = new GitHubClient(NullLogger<GitHubClient>.Instance, httpClient);

        await client.DeleteBranchProtectionAsync(Owner, Name, Branch);
    }
}
