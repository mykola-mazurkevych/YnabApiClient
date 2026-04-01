using mmazur.YnabApiClient.V1.Transactions;
using mmazur.YnabApiClient.V1.Transactions.Models;

using Soenneker.Utils.AutoBogus;

using Xunit;
using Xunit.Abstractions;

namespace mmazur.YnabApiClient.IntegrationTests.V1.Transactions;

public sealed class YnabV1ScheduledTransactionApiClientTests :
    YnabApiClientTestsBase
{
    private readonly AutoFaker _faker = new();

    private readonly IYnabV1ScheduledTransactionApiClient _ynabV1ScheduledTransactionApiClient;

    public YnabV1ScheduledTransactionApiClientTests(YnabApiClientTestsFixture fixture, ITestOutputHelper outputHelper) :
        base(fixture, outputHelper)
    {
        var budgetId = _faker.Generate<Guid>();
        var scheduledTransactionId = _faker.Generate<Guid>();

        _ynabV1ScheduledTransactionApiClient = YnabApiClient.V1.Budgets[budgetId].ScheduledTransactions[scheduledTransactionId];
    }

    [Fact(DisplayName = "Get Scheduled Transaction")]
    public async Task GetAsync_ShouldSucceed()
    {
        var scheduledTransactionResponse = await _ynabV1ScheduledTransactionApiClient.GetAsync();

        Assert.NotNull(scheduledTransactionResponse);
        Assert.NotNull(scheduledTransactionResponse.ScheduledTransaction);
    }

    [Fact(DisplayName = "Update Scheduled Transaction")]
    public async Task UpdateAsync_ShouldSucceed()
    {
        var saveScheduledTransaction = _faker.Generate<SaveScheduledTransaction>();

        var scheduledTransactionResponse = await _ynabV1ScheduledTransactionApiClient.UpdateAsync(saveScheduledTransaction);

        Assert.NotNull(scheduledTransactionResponse);
        Assert.NotNull(scheduledTransactionResponse.ScheduledTransaction);
    }

    [Fact(DisplayName = "Delete Scheduled Transaction")]
    public async Task DeleteAsync_ShouldSucceed()
    {
        var scheduledTransactionResponse = await _ynabV1ScheduledTransactionApiClient.DeleteAsync();

        Assert.NotNull(scheduledTransactionResponse);
        Assert.NotNull(scheduledTransactionResponse.ScheduledTransaction);
    }
}