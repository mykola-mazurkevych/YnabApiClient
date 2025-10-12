using mmazur.YnabApiClient.V1.Months;

using Xunit;
using Xunit.Abstractions;

namespace mmazur.YnabApiClient.IntegrationTests.V1.Months;

public sealed class YnabV1MonthsApiClientTests :
    YnabApiClientTestsBase
{
    private readonly IYnabV1MonthsApiClient _ynabV1MonthsApiClient;

    public YnabV1MonthsApiClientTests(YnabApiClientTestsFixture fixture, ITestOutputHelper outputHelper) :
        base(fixture, outputHelper)
    {
        var budgetId = this.Faker.Generate<Guid>();

        _ynabV1MonthsApiClient = this.YnabApiClient.V1.Budgets[budgetId].Months;
    }

    [Fact(DisplayName = "Get Months")]
    public async Task GetAsync_ShouldSucceed()
    {
        var monthsResponse = await _ynabV1MonthsApiClient.GetAsync();

        Assert.NotNull(monthsResponse);
        Assert.NotNull(monthsResponse.Months);
    }

    [Fact(DisplayName = "Get Months with Last Knowledge of Server")]
    public async Task GetAsync_WithLastKnowledgeOfServer_ShouldSucceed()
    {
        var lastKnowledgeOfServer = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

        var monthsResponse = await _ynabV1MonthsApiClient.GetAsync(lastKnowledgeOfServer);

        Assert.NotNull(monthsResponse);
        Assert.NotNull(monthsResponse.Months);
    }
}