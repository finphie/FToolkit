using System.Net;
using System.Net.Http.Json;
using Microsoft.Extensions.Logging.Abstractions;
using RichardSzalay.MockHttp;
using Xunit;

namespace FToolkit.Net.GitHub.Client.Tests;

public sealed class GitHubClientUpdateRepositoryAsyncTest
{
    const string Url = $"/repos/{Owner}/{Name}";

    const string Owner = "finphie";
    const string Name = "test";

    const string Json = /*lang=json,strict*/ """
        {"has_issues":true,"has_projects":true,"has_wiki":true,"has_discussions":true,"allow_merge_commit":true,"allow_squash_merge":true,"allow_rebase_merge":true,"allow_auto_merge":true,"delete_branch_on_merge":true,"allow_update_branch":true,"merge_commit_title":"PR_TITLE","merge_commit_message":"PR_BODY","squash_merge_commit_title":"PR_TITLE","squash_merge_commit_message":"PR_BODY"}
        """;

    static readonly Uri BaseAddress = new("http://localhost");

    [Fact]
    public async Task 各種設定を渡す_正常終了()
    {
        using var handler = new MockHttpMessageHandler();

        handler.Expect(HttpMethod.Patch, Url)
            .With(static message => Matcher(message, Json))
            .Respond(HttpStatusCode.OK);

        handler.Expect(HttpMethod.Patch, Url)
           .With(static message => Matcher(message, "{}"))
           .Respond(HttpStatusCode.OK);

        var httpClient = handler.ToHttpClient();
        httpClient.BaseAddress = BaseAddress;

        var client = new GitHubClient(NullLogger<GitHubClient>.Instance, httpClient);

        await client.UpdateRepositoryAsync(Owner, Name, new()
        {
            HasIssues = true,
            HasProjects = true,
            HasWiki = true,
            HasDiscussions = true,
            AllowMergeCommit = true,
            AllowSquashMerge = true,
            AllowRebaseMerge = true,
            AllowAutoMerge = true,
            DeleteBranchOnMerge = true,
            AllowUpdateBranch = true,
            MergeCommitTitle = "PR_TITLE",
            MergeCommitMessage = "PR_BODY",
            SquashMergeCommitTitle = "PR_TITLE",
            SquashMergeCommitMessage = "PR_BODY"
        });

        await client.UpdateRepositoryAsync(Owner, Name, new());

        handler.VerifyNoOutstandingExpectation();

        static bool Matcher(HttpRequestMessage message, string json)
        {
            if (message.Content is not JsonContent content)
            {
                return false;
            }

#pragma warning disable
            var text = content.ReadAsStringAsync().GetAwaiter().GetResult();
#pragma warning restore

            return text == json;
        }
    }
}
