using mmazur.YnabApiClient.V1.Transactions;
using mmazur.YnabApiClient.V1.Transactions.Models;

using Xunit;
using Xunit.Abstractions;

namespace mmazur.YnabApiClient.IntegrationTests.V1.Transactions;

public sealed class YnabV1TransactionsApiClientTests :
    YnabApiClientTestsBase
{
    private readonly IYnabV1TransactionsApiClient _ynabV1TransactionsApiClient;

    public YnabV1TransactionsApiClientTests(YnabApiClientTestsFixture fixture, ITestOutputHelper outputHelper) :
        base(fixture, outputHelper)
    {
        var budgetId = this.Faker.Generate<Guid>();

        _ynabV1TransactionsApiClient = this.YnabApiClient.V1.Budgets[budgetId].Transactions;
    }

    [Fact(DisplayName = "Get Transactions")]
    public async Task GetAsync_ShouldSucceed()
    {
        var transactionsResponse = await _ynabV1TransactionsApiClient.GetAsync();

        Assert.NotNull(transactionsResponse);
        Assert.NotNull(transactionsResponse.Transactions);
    }

    [Fact(DisplayName = "Get Transactions with Since Date")]
    public async Task GetAsync_WithSinceDate_ShouldSucceed()
    {
        var sinceDate = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(-30));

        var transactionsResponse = await _ynabV1TransactionsApiClient.GetAsync(sinceDate);

        Assert.NotNull(transactionsResponse);
        Assert.NotNull(transactionsResponse.Transactions);
    }

    [Fact(DisplayName = "Get Transactions with Since Date and Transaction Type")]
    public async Task GetAsync_WithSinceDateAndTransactionType_ShouldSucceed()
    {
        var sinceDate = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(-30));
        var transactionType = TransactionType.Uncategorized;

        var transactionsResponse = await _ynabV1TransactionsApiClient.GetAsync(sinceDate, transactionType);

        Assert.NotNull(transactionsResponse);
        Assert.NotNull(transactionsResponse.Transactions);
    }

    [Fact(DisplayName = "Get Transactions with Since Date and Last Knowledge of Server")]
    public async Task GetAsync_WithSinceDateAndLastKnowledgeOfServer_ShouldSucceed()
    {
        var sinceDate = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(-30));
        var lastKnowledgeOfServer = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

        var transactionsResponse = await _ynabV1TransactionsApiClient.GetAsync(sinceDate, lastKnowledgeOfServer);

        Assert.NotNull(transactionsResponse);
        Assert.NotNull(transactionsResponse.Transactions);
    }

    [Fact(DisplayName = "Get Transactions with Since Date, Transaction Type and Last Knowledge of Server")]
    public async Task GetAsync_WithSinceDateTransactionTypeAndLastKnowledgeOfServer_ShouldSucceed()
    {
        var sinceDate = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(-30));
        var transactionType = TransactionType.Unapproved;
        var lastKnowledgeOfServer = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

        var transactionsResponse = await _ynabV1TransactionsApiClient.GetAsync(sinceDate, transactionType, lastKnowledgeOfServer);

        Assert.NotNull(transactionsResponse);
        Assert.NotNull(transactionsResponse.Transactions);
    }

    [Fact(DisplayName = "Get Transactions with Transaction Type")]
    public async Task GetAsync_WithTransactionType_ShouldSucceed()
    {
        var transactionType = TransactionType.Uncategorized;

        var transactionsResponse = await _ynabV1TransactionsApiClient.GetAsync(transactionType);

        Assert.NotNull(transactionsResponse);
        Assert.NotNull(transactionsResponse.Transactions);
    }

    [Fact(DisplayName = "Get Transactions with Transaction Type and Last Knowledge of Server")]
    public async Task GetAsync_WithTransactionTypeAndLastKnowledgeOfServer_ShouldSucceed()
    {
        var transactionType = TransactionType.Unapproved;
        var lastKnowledgeOfServer = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

        var transactionsResponse = await _ynabV1TransactionsApiClient.GetAsync(transactionType, lastKnowledgeOfServer);

        Assert.NotNull(transactionsResponse);
        Assert.NotNull(transactionsResponse.Transactions);
    }

    [Fact(DisplayName = "Get Transactions with Last Knowledge of Server")]
    public async Task GetAsync_WithLastKnowledgeOfServer_ShouldSucceed()
    {
        var lastKnowledgeOfServer = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

        var transactionsResponse = await _ynabV1TransactionsApiClient.GetAsync(lastKnowledgeOfServer);

        Assert.NotNull(transactionsResponse);
        Assert.NotNull(transactionsResponse.Transactions);
    }

    [Fact(DisplayName = "Create Transaction")]
    public async Task CreateAsync_ShouldSucceed()
    {
        var newTransaction = this.Faker.Generate<NewTransaction>();

        var saveTransactionResponse = await _ynabV1TransactionsApiClient.CreateAsync(newTransaction);

        Assert.NotNull(saveTransactionResponse);
        Assert.NotNull(saveTransactionResponse.Transaction);
    }

    [Fact(DisplayName = "Create Multiple Transactions")]
    public async Task CreateAsync_MultipleTransactions_ShouldSucceed()
    {
        var newTransactions = this.Faker.Generate<NewTransaction>(3);

        var saveTransactionsResponse = await _ynabV1TransactionsApiClient.CreateAsync(newTransactions);

        Assert.NotNull(saveTransactionsResponse);
        Assert.NotNull(saveTransactionsResponse.Transactions);
    }

    [Fact(DisplayName = "Update Transaction")]
    public async Task UpdateAsync_ShouldSucceed()
    {
        var saveTransaction = this.Faker.Generate<SaveTransactionWithIdOrImportId>();

        var saveTransactionResponse = await _ynabV1TransactionsApiClient.UpdateAsync(saveTransaction);

        Assert.NotNull(saveTransactionResponse);
        Assert.NotNull(saveTransactionResponse.Transaction);
    }

    [Fact(DisplayName = "Update Multiple Transactions")]
    public async Task UpdateAsync_MultipleTransactions_ShouldSucceed()
    {
        var saveTransactions = this.Faker.Generate<SaveTransactionWithIdOrImportId>(3);

        var saveTransactionsResponse = await _ynabV1TransactionsApiClient.UpdateAsync(saveTransactions);

        Assert.NotNull(saveTransactionsResponse);
        Assert.NotNull(saveTransactionsResponse.Transactions);
    }
}