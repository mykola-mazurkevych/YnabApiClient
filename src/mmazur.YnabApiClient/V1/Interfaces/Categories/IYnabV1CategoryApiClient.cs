using mmazur.YnabApiClient.V1.Models.Categories;

namespace mmazur.YnabApiClient.V1.Interfaces.Categories;

public interface IYnabV1CategoryApiClient
{
    /// <summary>
    /// Single category
    /// Returns a single category. Amounts (budgeted, activity, balance, etc.) are specific to the current budget month (UTC).
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<CategoryResponse> GetAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Update a category
    /// </summary>
    /// <param name="category">Category to update.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<CategoryResponse> UpdateAsync(UpdateCategory category, CancellationToken cancellationToken = default);
}