using mmazur.YnabApiClient.V1.Budgets;

using Xunit;
using Xunit.Abstractions;

namespace mmazur.YnabApiClient.IntegrationTests.V1.Budgets;

public sealed class YnabV1BudgetsApiClientTests :
    YnabApiClientTestsBase
{
    private readonly IYnabV1BudgetsApiClient _ynabV1BudgetsApiClient;

    public YnabV1BudgetsApiClientTests(YnabApiClientTestsFixture fixture, ITestOutputHelper outputHelper) :
        base(fixture, outputHelper)
    {
        _ynabV1BudgetsApiClient = this.YnabApiClient.V1.Budgets;
    }

    [Fact(DisplayName = "Get Budgets")]
    public async Task GetAsync_ShouldSucceed()
    {
        var budgetSummaryResponse = await _ynabV1BudgetsApiClient.GetAsync();

        Assert.NotNull(budgetSummaryResponse);
        Assert.NotNull(budgetSummaryResponse.Budgets);
    }

    [Fact(DisplayName = "Get Budgets with Include Accounts")]
    public async Task GetAsync_WithIncludeAccounts_ShouldSucceed()
    {
        var includeAccounts = this.Faker.Generate<bool>();

        var budgetSummaryResponse = await _ynabV1BudgetsApiClient.GetAsync(includeAccounts);

        Assert.NotNull(budgetSummaryResponse);
        Assert.NotNull(budgetSummaryResponse.Budgets);
    }
}