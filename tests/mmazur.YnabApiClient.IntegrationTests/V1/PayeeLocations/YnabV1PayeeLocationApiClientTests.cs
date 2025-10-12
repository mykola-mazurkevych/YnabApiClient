using mmazur.YnabApiClient.V1.PayeeLocations;

using Xunit;
using Xunit.Abstractions;

namespace mmazur.YnabApiClient.IntegrationTests.V1.PayeeLocations;

public sealed class YnabV1PayeeLocationApiClientTests :
    YnabApiClientTestsBase
{
    private readonly IYnabV1PayeeLocationApiClient _ynabV1PayeeLocationApiClient;

    public YnabV1PayeeLocationApiClientTests(YnabApiClientTestsFixture fixture, ITestOutputHelper outputHelper) :
        base(fixture, outputHelper)
    {
        var budgetId = this.Faker.Generate<Guid>();
        var payeeLocationId = this.Faker.Generate<Guid>();

        _ynabV1PayeeLocationApiClient = this.YnabApiClient.V1.Budgets[budgetId].PayeeLocations[payeeLocationId];
    }

    [Fact(DisplayName = "Get Payee Location")]
    public async Task GetAsync_ShouldSucceed()
    {
        var payeeLocationResponse = await _ynabV1PayeeLocationApiClient.GetAsync();

        Assert.NotNull(payeeLocationResponse);
        Assert.NotNull(payeeLocationResponse.PayeeLocation);
    }
}