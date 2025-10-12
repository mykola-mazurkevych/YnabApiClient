using mmazur.YnabApiClient.V1.Categories;

namespace mmazur.YnabApiClient.V1.Months;

public interface IYnabV1MonthCategoriesApiClient
{
    IYnabV1CategoriesCategoryApiClient Categories { get; }
}