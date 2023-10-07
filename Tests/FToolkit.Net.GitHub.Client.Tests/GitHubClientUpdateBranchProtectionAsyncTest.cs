using System.Net;
using System.Net.Http.Json;
using Microsoft.Extensions.Logging.Abstractions;
using RichardSzalay.MockHttp;
using Xunit;

namespace FToolkit.Net.GitHub.Client.Tests;

public sealed class GitHubClientUpdateBranchProtectionAsyncTest
{
    const string Url = $"/repos/{Owner}/{Name}/branches/{Branch}/protection";

    const string Owner = "finphie";
    const string Name = "test";
    const string Branch = "main";

    const string Json1 = /*lang=json,strict*/ """
        {"enforce_admins":true,"required_linear_history":true,"allow_force_pushes":true,"allow_deletions":true,"required_conversation_resolution":true,"required_status_checks":{"strict":true,"contexts":["test1","test2"]},"required_pull_request_reviews":{"dismiss_stale_reviews":true,"require_code_owner_reviews":true,"required_approving_review_count":1},"restrictions":null}
        """;

    const string Json2 = /*lang=json,strict*/ """
        {"enforce_admins":false,"required_status_checks":null,"required_pull_request_reviews":null,"restrictions":null}
        """;

    static readonly Uri BaseAddress = new("http://localhost");

    [Fact]
    public async Task 各種設定を渡す_正常終了()
    {
        var handler = new MockHttpMessageHandler();

        handler.Expect(HttpMethod.Put, Url)
            .With(static message => Matcher(message, Json1))
            .Respond(HttpStatusCode.OK);

        handler.Expect(HttpMethod.Put, Url)
           .With(static message => Matcher(message, Json2))
           .Respond(HttpStatusCode.OK);

        var httpClient = handler.ToHttpClient();
        httpClient.BaseAddress = BaseAddress;

        var client = new GitHubClient(NullLogger<GitHubClient>.Instance, httpClient);

        await client.UpdateBranchProtectionAsync(Owner, Name, Branch, new()
        {
            EnforceAdmins = true,
            RequiredLinearHistory = true,
            AllowForcePushes = true,
            AllowDeletions = true,
            RequiredConversationResolution = true,
            RequiredStatusChecks = new()
            {
                Strict = true,
#pragma warning disable SA1010 // Opening square brackets should be spaced correctly
                Contexts = ["test1", "test2"]
#pragma warning restore SA1010 // Opening square brackets should be spaced correctly
            },
            RequiredPullRequestReviews = new()
            {
                DismissStaleReviews = true,
                RequireCodeOwnerReviews = true,
                RequiredApprovingReviewCount = 1
            }
        });

        await client.UpdateBranchProtectionAsync(Owner, Name, Branch, new());

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
