using mmazur.YnabApiClient.V1.Categories;

using Xunit;
using Xunit.Abstractions;

namespace mmazur.YnabApiClient.IntegrationTests.V1.Categories;

public sealed class YnabV1CategoriesApiClientTests :
    YnabApiClientTestsBase
{
    private readonly IYnabV1CategoriesApiClient _ynabV1CategoriesApiClient;

    public YnabV1CategoriesApiClientTests(YnabApiClientTestsFixture fixture, ITestOutputHelper outputHelper) :
        base(fixture, outputHelper)
    {
        var budgetId = this.Faker.Generate<Guid>();

        _ynabV1CategoriesApiClient = this.YnabApiClient.V1.Budgets[budgetId].Categories;
    }

    [Fact(DisplayName = "Get Categories")]
    public async Task GetAsync_ShouldSucceed()
    {
        var categoriesResponse = await _ynabV1CategoriesApiClient.GetAsync();

        Assert.NotNull(categoriesResponse);
        Assert.NotNull(categoriesResponse.CategoryGroups);
    }

    [Fact(DisplayName = "Get Categories with Last Knowledge of Server")]
    public async Task GetAsync_WithLastKnowledgeOfServer_ShouldSucceed()
    {
        var lastKnowledgeOfServer = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

        var categoriesResponse = await _ynabV1CategoriesApiClient.GetAsync(lastKnowledgeOfServer);

        Assert.NotNull(categoriesResponse);
        Assert.NotNull(categoriesResponse.CategoryGroups);
    }
}