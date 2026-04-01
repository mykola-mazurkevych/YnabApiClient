using mmazur.YnabApiClient.V1.Budgets;

using Xunit;
using Xunit.Abstractions;

namespace mmazur.YnabApiClient.IntegrationTests.V1.Budgets;

public sealed class YnabV1BudgetSettingsApiClientTests :
    YnabApiClientTestsBase
{
    private readonly IYnabV1BudgetSettingsApiClient _ynabV1BudgetSettingsApiClient;

    public YnabV1BudgetSettingsApiClientTests(YnabApiClientTestsFixture fixture, ITestOutputHelper outputHelper) :
        base(fixture, outputHelper)
    {
        var budgetId = Faker.Generate<Guid>();

        _ynabV1BudgetSettingsApiClient = YnabApiClient.V1.Budgets[budgetId].Settings;
    }

    [Fact(DisplayName = "Get Budget Settings")]
    public async Task GetAsync_ShouldSucceed()
    {
        var budgetSettingsResponse = await _ynabV1BudgetSettingsApiClient.GetAsync();

        Assert.NotNull(budgetSettingsResponse);
        Assert.NotNull(budgetSettingsResponse.Settings);
    }
}