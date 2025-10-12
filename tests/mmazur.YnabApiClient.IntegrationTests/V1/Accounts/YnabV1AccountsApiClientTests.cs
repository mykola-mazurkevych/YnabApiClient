
using mmazur.YnabApiClient.V1.Accounts;
using mmazur.YnabApiClient.V1.Accounts.Models;

using Xunit;
using Xunit.Abstractions;

namespace mmazur.YnabApiClient.IntegrationTests.V1.Accounts;

public sealed class YnabV1AccountsApiClientTests :
    YnabApiClientTestsBase
{
    private readonly IYnabV1AccountsApiClient _ynabV1AccountsApiClient;

    public YnabV1AccountsApiClientTests(YnabApiClientTestsFixture fixture, ITestOutputHelper outputHelper) :
        base(fixture, outputHelper)
    {
        var budgetId = this.Faker.Generate<Guid>();

        _ynabV1AccountsApiClient = this.YnabApiClient.V1.Budgets[budgetId].Accounts;
    }

    [Fact(DisplayName = "Get Account")]
    public async Task GetAsync_ShouldSucceed()
    {
        var accountsResponse = await _ynabV1AccountsApiClient.GetAsync();

        Assert.NotNull(accountsResponse);
        Assert.NotNull(accountsResponse.Accounts);
    }

    [Fact(DisplayName = "Get Account with Last Knowledge of Server")]
    public async Task GetAsync_WithLastKnowledgeOfServer_ShouldSucceed()
    {
        var lastKnowledgeOfServer = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

        var accountsResponse = await _ynabV1AccountsApiClient.GetAsync(lastKnowledgeOfServer);

        Assert.NotNull(accountsResponse);
        Assert.NotNull(accountsResponse.Accounts);
    }

    [Fact(DisplayName = "Create Account")]
    public async Task CreateAsync_ShouldSucceed()
    {
        var saveAccount = this.Faker.Generate<SaveAccount>();

        var accountResponse = await _ynabV1AccountsApiClient.CreateAsync(saveAccount);

        Assert.NotNull(accountResponse);
        Assert.NotNull(accountResponse.Account);
    }
}