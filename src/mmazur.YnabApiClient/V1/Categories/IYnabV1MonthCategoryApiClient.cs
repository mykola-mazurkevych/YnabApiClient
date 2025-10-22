using mmazur.YnabApiClient.V1.Categories.Models;

namespace mmazur.YnabApiClient.V1.Categories;

public interface IYnabV1MonthCategoryApiClient
{
    /// <summary>
    /// Single category for a specific budget month
    /// Returns a single category for a specific budget month. Amounts(budgeted, activity, balance, etc.) are specific to the current budget month(UTC).
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<CategoryResponse?> GetAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Update a category for a specific month
    /// Update a category for a specific month. Only budgeted amount can be updated.
    /// </summary>
    /// <param name="category">The category to update. Only budgeted amount can be updated and any other fields specified will be ignored.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<SaveCategoryResponse> UpdateAsync(SaveMonthCategory category, CancellationToken cancellationToken = default);
}