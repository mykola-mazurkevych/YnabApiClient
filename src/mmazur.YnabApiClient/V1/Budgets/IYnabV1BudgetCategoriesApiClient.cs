using mmazur.YnabApiClient.V1.Categories;

namespace mmazur.YnabApiClient.V1.Budgets;

public interface IYnabV1BudgetCategoriesApiClient
{
    IYnabV1CategoriesApiClient Categories { get; }
}