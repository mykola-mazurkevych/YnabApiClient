using mmazur.YnabApiClient.V1.Accounts;

using Xunit;
using Xunit.Abstractions;

namespace mmazur.YnabApiClient.IntegrationTests.V1.Accounts;

public sealed class YnabV1AccountApiClientTests :
    YnabApiClientTestsBase
{
    private readonly IYnabV1AccountApiClient _ynabV1AccountApiClient;

    public YnabV1AccountApiClientTests(YnabApiClientTestsFixture fixture, ITestOutputHelper outputHelper) :
        base(fixture, outputHelper)
    {
        var budgetId = this.Faker.Generate<Guid>();
        var accountId = this.Faker.Generate<Guid>();

        _ynabV1AccountApiClient = this.YnabApiClient.V1.Budgets[budgetId].Accounts[accountId];
    }

    [Fact(DisplayName = "Get Account")]
    public async Task GetAsync_ShouldSucceed()
    {
        var accountResponse = await _ynabV1AccountApiClient.GetAsync();

        Assert.NotNull(accountResponse);
        Assert.NotNull(accountResponse.Account);
    }

    [Fact(DisplayName = "Get Account Transactions")]
    public async Task Transactions_GetAsync_ShouldSucceed()
    {
        var transactionsResponse = await _ynabV1AccountApiClient.Transactions.GetAsync();

        Assert.NotNull(transactionsResponse);
    }
}