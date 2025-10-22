using mmazur.YnabApiClient.V1.Categories.Models;
using mmazur.YnabApiClient.V1.Months;

using Xunit;
using Xunit.Abstractions;

namespace mmazur.YnabApiClient.IntegrationTests.V1.Months;

public sealed class YnabV1MonthApiClientTests :
    YnabApiClientTestsBase
{
    private readonly IYnabV1MonthApiClient _ynabV1MonthApiClient;

    public YnabV1MonthApiClientTests(YnabApiClientTestsFixture fixture, ITestOutputHelper outputHelper) :
        base(fixture, outputHelper)
    {
        var budgetId = this.Faker.Generate<Guid>();
        var month = this.Faker.Generate<DateOnly>();

        _ynabV1MonthApiClient = this.YnabApiClient.V1.Budgets[budgetId].Months[month];
    }

    [Fact(DisplayName = "Get Month")]
    public async Task GetAsync_ShouldSucceed()
    {
        var monthResponse = await _ynabV1MonthApiClient.GetAsync();

        Assert.NotNull(monthResponse);
        Assert.NotNull(monthResponse.Month);
    }

    [Fact(DisplayName = "Get Month Category")]
    public async Task Category_GetAsync_ShouldSucceed()
    {
        var categoryId = this.Faker.Generate<Guid>();

        var categoryResponse = await _ynabV1MonthApiClient.Categories[categoryId].GetAsync();

        Assert.NotNull(categoryResponse);
        Assert.NotNull(categoryResponse.Category);
    }

    [Fact(DisplayName = "Update Month Category")]
    public async Task Category_UpdateAsync_ShouldSucceed()
    {
        var categoryId = this.Faker.Generate<Guid>();
        var saveMonthCategory = this.Faker.Generate<SaveMonthCategory>();

        var saveCategoryResponse = await _ynabV1MonthApiClient.Categories[categoryId].UpdateAsync(saveMonthCategory);

        Assert.NotNull(saveCategoryResponse);
        Assert.NotNull(saveCategoryResponse.Category);
    }

    [Fact(DisplayName = "Get Month Transactions")]
    public async Task Transactions_GetAsync_ShouldSucceed()
    {
        var transactionsResponse = await _ynabV1MonthApiClient.Transactions.GetAsync();

        Assert.NotNull(transactionsResponse);
    }
}