using mmazur.YnabApiClient.V1.Transactions;
using mmazur.YnabApiClient.V1.Transactions.Models;

using Xunit;
using Xunit.Abstractions;

namespace mmazur.YnabApiClient.IntegrationTests.V1.Transactions;

public sealed class YnabV1ScheduledTransactionsApiClientTests :
    YnabApiClientTestsBase
{
    private readonly IYnabV1ScheduledTransactionsApiClient _ynabV1ScheduledTransactionsApiClient;

    public YnabV1ScheduledTransactionsApiClientTests(YnabApiClientTestsFixture fixture, ITestOutputHelper outputHelper) :
        base(fixture, outputHelper)
    {
        var budgetId = Faker.Generate<Guid>();

        _ynabV1ScheduledTransactionsApiClient = YnabApiClient.V1.Budgets[budgetId].ScheduledTransactions;
    }

    [Fact(DisplayName = "Get Scheduled Transactions")]
    public async Task GetAsync_ShouldSucceed()
    {
        var scheduledTransactionsResponse = await _ynabV1ScheduledTransactionsApiClient.GetAsync();

        Assert.NotNull(scheduledTransactionsResponse);
        Assert.NotNull(scheduledTransactionsResponse.ScheduledTransactions);
    }

    [Fact(DisplayName = "Get Scheduled Transactions with Last Knowledge of Server")]
    public async Task GetAsync_WithLastKnowledgeOfServer_ShouldSucceed()
    {
        var lastKnowledgeOfServer = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

        var scheduledTransactionsResponse = await _ynabV1ScheduledTransactionsApiClient.GetAsync(lastKnowledgeOfServer);

        Assert.NotNull(scheduledTransactionsResponse);
        Assert.NotNull(scheduledTransactionsResponse.ScheduledTransactions);
    }

    [Fact(DisplayName = "Create Scheduled Transaction")]
    public async Task CreateAsync_ShouldSucceed()
    {
        var saveScheduledTransaction = Faker.Generate<SaveScheduledTransaction>();

        var scheduledTransactionResponse = await _ynabV1ScheduledTransactionsApiClient.CreateAsync(saveScheduledTransaction);

        Assert.NotNull(scheduledTransactionResponse);
        Assert.NotNull(scheduledTransactionResponse.ScheduledTransaction);
    }
}