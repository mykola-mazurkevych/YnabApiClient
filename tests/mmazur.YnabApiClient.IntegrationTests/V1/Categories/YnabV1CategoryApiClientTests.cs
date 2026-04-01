using mmazur.YnabApiClient.V1.Categories;
using mmazur.YnabApiClient.V1.Categories.Models;

using Xunit;
using Xunit.Abstractions;

namespace mmazur.YnabApiClient.IntegrationTests.V1.Categories;

public sealed class YnabV1CategoryApiClientTests :
    YnabApiClientTestsBase
{
    private readonly IYnabV1CategoryApiClient _ynabV1CategoryApiClient;

    public YnabV1CategoryApiClientTests(YnabApiClientTestsFixture fixture, ITestOutputHelper outputHelper) :
        base(fixture, outputHelper)
    {
        var budgetId = Faker.Generate<Guid>();
        var categoryId = Faker.Generate<Guid>();

        _ynabV1CategoryApiClient = YnabApiClient.V1.Budgets[budgetId].Categories[categoryId];
    }

    [Fact(DisplayName = "Get Category")]
    public async Task GetAsync_ShouldSucceed()
    {
        var categoryResponse = await _ynabV1CategoryApiClient.GetAsync();

        Assert.NotNull(categoryResponse);
        Assert.NotNull(categoryResponse.Category);
    }

    [Fact(DisplayName = "Update Category")]
    public async Task UpdateAsync_ShouldSucceed()
    {
        var saveCategory = Faker.Generate<SaveCategory>();

        var saveCategoryResponse = await _ynabV1CategoryApiClient.UpdateAsync(saveCategory);

        Assert.NotNull(saveCategoryResponse);
        Assert.NotNull(saveCategoryResponse.Category);
    }

    [Fact(DisplayName = "Get Account Transactions")]
    public async Task Transactions_GetAsync_ShouldSucceed()
    {
        var transactionsResponse = await _ynabV1CategoryApiClient.Transactions.GetAsync();

        Assert.NotNull(transactionsResponse);
    }
}