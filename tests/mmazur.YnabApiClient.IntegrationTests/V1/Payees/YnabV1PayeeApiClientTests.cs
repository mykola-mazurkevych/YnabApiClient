using mmazur.YnabApiClient.V1.Payees;
using mmazur.YnabApiClient.V1.Payees.Models;

using Xunit;
using Xunit.Abstractions;

namespace mmazur.YnabApiClient.IntegrationTests.V1.Payees;

public sealed class YnabV1PayeeApiClientTests :
    YnabApiClientTestsBase
{
    private readonly IYnabV1PayeeApiClient _ynabV1PayeeApiClient;

    public YnabV1PayeeApiClientTests(YnabApiClientTestsFixture fixture, ITestOutputHelper outputHelper) :
        base(fixture, outputHelper)
    {
        var budgetId = this.Faker.Generate<Guid>();
        var payeeId = this.Faker.Generate<Guid>();

        _ynabV1PayeeApiClient = this.YnabApiClient.V1.Budgets[budgetId].Payees[payeeId];
    }

    [Fact(DisplayName = "Get Payee")]
    public async Task GetAsync_ShouldSucceed()
    {
        var payeeResponse = await _ynabV1PayeeApiClient.GetAsync();

        Assert.NotNull(payeeResponse);
        Assert.NotNull(payeeResponse.Payee);
    }

    [Fact(DisplayName = "Update Payee")]
    public async Task UpdateAsync_ShouldSucceed()
    {
        var savePayee = this.Faker.Generate<SavePayee>();

        var savePayeeResponse = await _ynabV1PayeeApiClient.UpdateAsync(savePayee);

        Assert.NotNull(savePayeeResponse);
        Assert.NotNull(savePayeeResponse.Payee);
    }

    [Fact(DisplayName = "Get Payee Locations")]
    public async Task Locations_GetAsync_ShouldSucceed()
    {
        var locationsResponse = await _ynabV1PayeeApiClient.Locations.GetAsync();

        Assert.NotNull(locationsResponse);
        Assert.NotNull(locationsResponse.PayeeLocations);
    }

    [Fact(DisplayName = "Get Payee Transactions")]
    public async Task Transactions_GetAsync_ShouldSucceed()
    {
        var transactionsResponse = await _ynabV1PayeeApiClient.Transactions.GetAsync();

        Assert.NotNull(transactionsResponse);
    }
}