using mmazur.YnabApiClient.V1.Transactions;
using mmazur.YnabApiClient.V1.Transactions.Models;

using Xunit;
using Xunit.Abstractions;

namespace mmazur.YnabApiClient.IntegrationTests.V1.Transactions;

public sealed class YnabV1TransactionApiClientTests :
    YnabApiClientTestsBase
{
    private readonly IYnabV1TransactionApiClient _ynabV1TransactionApiClient;

    public YnabV1TransactionApiClientTests(YnabApiClientTestsFixture fixture, ITestOutputHelper outputHelper) :
        base(fixture, outputHelper)
    {
        var budgetId = this.Faker.Generate<Guid>();
        var transactionId = this.Faker.Generate<Guid>().ToString();

        _ynabV1TransactionApiClient = this.YnabApiClient.V1.Budgets[budgetId].Transactions[transactionId];
    }

    [Fact(DisplayName = "Get Transaction")]
    public async Task GetAsync_ShouldSucceed()
    {
        var transactionResponse = await _ynabV1TransactionApiClient.GetAsync();

        Assert.NotNull(transactionResponse);
        Assert.NotNull(transactionResponse.Transaction);
    }

    [Fact(DisplayName = "Update Transaction")]
    public async Task UpdateAsync_ShouldSucceed()
    {
        var existingTransaction = this.Faker.Generate<ExistingTransaction>();

        var transactionResponse = await _ynabV1TransactionApiClient.UpdateAsync(existingTransaction);

        Assert.NotNull(transactionResponse);
        Assert.NotNull(transactionResponse.Transaction);
    }

    [Fact(DisplayName = "Delete Transaction")]
    public async Task DeleteAsync_ShouldSucceed()
    {
        var transactionResponse = await _ynabV1TransactionApiClient.DeleteAsync();

        Assert.NotNull(transactionResponse);
        Assert.NotNull(transactionResponse.Transaction);
    }
}