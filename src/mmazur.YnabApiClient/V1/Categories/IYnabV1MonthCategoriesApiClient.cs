namespace mmazur.YnabApiClient.V1.Categories;

public interface IYnabV1MonthCategoriesApiClient
{
    IYnabV1MonthCategoryApiClient this[Guid categoryId] { get; }
}