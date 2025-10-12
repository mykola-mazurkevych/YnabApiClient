using mmazur.YnabApiClient.V1.Budgets;

using Xunit;
using Xunit.Abstractions;

namespace mmazur.YnabApiClient.IntegrationTests.V1.Budgets;

public sealed class YnabV1BudgetApiClientTests :
    YnabApiClientTestsBase
{
    private readonly IYnabV1BudgetApiClient _ynabV1BudgetApiClient;
    private readonly IYnabV1BudgetApiClient _ynabV1DefaultBudgetApiClient;
    private readonly IYnabV1BudgetApiClient _ynabV1LastUsedBudgetApiClient;

    public YnabV1BudgetApiClientTests(YnabApiClientTestsFixture fixture, ITestOutputHelper outputHelper) :
        base(fixture, outputHelper)
    {
        var budgetId = this.Faker.Generate<Guid>();

        _ynabV1BudgetApiClient = this.YnabApiClient.V1.Budgets[budgetId];
        _ynabV1DefaultBudgetApiClient = this.YnabApiClient.V1.Budgets.Default;
        _ynabV1LastUsedBudgetApiClient = this.YnabApiClient.V1.Budgets.LastUsed;
    }

    [Fact(DisplayName = "Get Budget")]
    public async Task GetAsync_ShouldSucceed()
    {
        var budgetDetailResponse = await _ynabV1BudgetApiClient.GetAsync();

        Assert.NotNull(budgetDetailResponse);
        Assert.NotNull(budgetDetailResponse.Budget);
    }

    [Fact(DisplayName = "Get Budget with Last Knowledge of Server")]
    public async Task GetAsync_WithLastKnowledgeOfServer_ShouldSucceed()
    {
        var lastKnowledgeOfServer = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

        var budgetDetailResponse = await _ynabV1BudgetApiClient.GetAsync(lastKnowledgeOfServer);

        Assert.NotNull(budgetDetailResponse);
        Assert.NotNull(budgetDetailResponse.Budget);
    }

    [Fact(DisplayName = "Get Default Budget")]
    public async Task GetAsync_DefaultBudget_ShouldSucceed()
    {
        var budgetDetailResponse = await _ynabV1DefaultBudgetApiClient.GetAsync();

        Assert.NotNull(budgetDetailResponse);
        Assert.NotNull(budgetDetailResponse.Budget);
    }

    [Fact(DisplayName = "Get Last Used Budget")]
    public async Task GetAsync_LastUsedBudget_ShouldSucceed()
    {
        var budgetDetailResponse = await _ynabV1LastUsedBudgetApiClient.GetAsync();

        Assert.NotNull(budgetDetailResponse);
        Assert.NotNull(budgetDetailResponse.Budget);
    }

    [Fact(DisplayName = "Get Budget Accounts")]
    public async Task Accounts_GetAsync_ShouldSucceed()
    {
        var accountsResponse = await _ynabV1BudgetApiClient.Accounts.GetAsync();

        Assert.NotNull(accountsResponse);
        Assert.NotNull(accountsResponse.Accounts);
    }

    [Fact(DisplayName = "Get Budget Categories")]
    public async Task Categories_GetAsync_ShouldSucceed()
    {
        var categoriesResponse = await _ynabV1BudgetApiClient.Categories.GetAsync();

        Assert.NotNull(categoriesResponse);
        Assert.NotNull(categoriesResponse.CategoryGroups);
    }

    [Fact(DisplayName = "Get Budget Months")]
    public async Task Months_GetAsync_ShouldSucceed()
    {
        var monthsResponse = await _ynabV1BudgetApiClient.Months.GetAsync();

        Assert.NotNull(monthsResponse);
        Assert.NotNull(monthsResponse.Months);
    }

    [Fact(DisplayName = "Get Budget Payees")]
    public async Task Payees_GetAsync_ShouldSucceed()
    {
        var payeesResponse = await _ynabV1BudgetApiClient.Payees.GetAsync();

        Assert.NotNull(payeesResponse);
        Assert.NotNull(payeesResponse.Payees);
    }

    [Fact(DisplayName = "Get Budget Payee Locations")]
    public async Task PayeeLocations_GetAsync_ShouldSucceed()
    {
        var payeeLocationsResponse = await _ynabV1BudgetApiClient.PayeeLocations.GetAsync();

        Assert.NotNull(payeeLocationsResponse);
        Assert.NotNull(payeeLocationsResponse.PayeeLocations);
    }

    [Fact(DisplayName = "Get Budget Transactions")]
    public async Task Transactions_GetAsync_ShouldSucceed()
    {
        var transactionsResponse = await _ynabV1BudgetApiClient.Transactions.GetAsync();

        Assert.NotNull(transactionsResponse);
        Assert.NotNull(transactionsResponse.Transactions);
    }

    [Fact(DisplayName = "Get Budget Scheduled Transactions")]
    public async Task ScheduledTransactions_GetAsync_ShouldSucceed()
    {
        var scheduledTransactionsResponse = await _ynabV1BudgetApiClient.ScheduledTransactions.GetAsync();

        Assert.NotNull(scheduledTransactionsResponse);
        Assert.NotNull(scheduledTransactionsResponse.ScheduledTransactions);
    }

    [Fact(DisplayName = "Get Budget Settings")]
    public async Task Settings_GetAsync_ShouldSucceed()
    {
        var budgetSettingsResponse = await _ynabV1BudgetApiClient.Settings.GetAsync();

        Assert.NotNull(budgetSettingsResponse);
        Assert.NotNull(budgetSettingsResponse.Settings);
    }
}