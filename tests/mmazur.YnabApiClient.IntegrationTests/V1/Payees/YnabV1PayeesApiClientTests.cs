using mmazur.YnabApiClient.V1.Payees;

using Xunit;
using Xunit.Abstractions;

namespace mmazur.YnabApiClient.IntegrationTests.V1.Payees;

public sealed class YnabV1PayeesApiClientTests :
    YnabApiClientTestsBase
{
    private readonly IYnabV1PayeesApiClient _ynabV1PayeesApiClient;

    public YnabV1PayeesApiClientTests(YnabApiClientTestsFixture fixture, ITestOutputHelper outputHelper) :
        base(fixture, outputHelper)
    {
        var budgetId = Faker.Generate<Guid>();

        _ynabV1PayeesApiClient = YnabApiClient.V1.Budgets[budgetId].Payees;
    }

    [Fact(DisplayName = "Get Payees")]
    public async Task GetAsync_ShouldSucceed()
    {
        var payeesResponse = await _ynabV1PayeesApiClient.GetAsync();

        Assert.NotNull(payeesResponse);
        Assert.NotNull(payeesResponse.Payees);
    }

    [Fact(DisplayName = "Get Payees with Last Knowledge of Server")]
    public async Task GetAsync_WithLastKnowledgeOfServer_ShouldSucceed()
    {
        var lastKnowledgeOfServer = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

        var payeesResponse = await _ynabV1PayeesApiClient.GetAsync(lastKnowledgeOfServer);

        Assert.NotNull(payeesResponse);
        Assert.NotNull(payeesResponse.Payees);
    }
}