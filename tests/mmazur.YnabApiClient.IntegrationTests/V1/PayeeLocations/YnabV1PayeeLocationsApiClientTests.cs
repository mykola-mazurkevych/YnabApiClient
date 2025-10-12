using mmazur.YnabApiClient.V1.PayeeLocations;

using Xunit;
using Xunit.Abstractions;

namespace mmazur.YnabApiClient.IntegrationTests.V1.PayeeLocations;

public sealed class YnabV1PayeeLocationsApiClientTests :
    YnabApiClientTestsBase
{
    private readonly IYnabV1PayeeLocationsApiClient _ynabV1PayeeLocationsApiClient;

    public YnabV1PayeeLocationsApiClientTests(YnabApiClientTestsFixture fixture, ITestOutputHelper outputHelper) :
        base(fixture, outputHelper)
    {
        var budgetId = this.Faker.Generate<Guid>();

        _ynabV1PayeeLocationsApiClient = this.YnabApiClient.V1.Budgets[budgetId].PayeeLocations;
    }

    [Fact(DisplayName = "Get Payee Locations")]
    public async Task GetAsync_ShouldSucceed()
    {
        var payeeLocationsResponse = await _ynabV1PayeeLocationsApiClient.GetAsync();

        Assert.NotNull(payeeLocationsResponse);
        Assert.NotNull(payeeLocationsResponse.PayeeLocations);
    }
}