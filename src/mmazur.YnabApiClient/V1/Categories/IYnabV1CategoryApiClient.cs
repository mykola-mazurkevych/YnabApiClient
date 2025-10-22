using mmazur.YnabApiClient.V1.Categories.Models;
using mmazur.YnabApiClient.V1.Transactions;

namespace mmazur.YnabApiClient.V1.Categories;

public interface IYnabV1CategoryApiClient
{
    IYnabV1TransactionsGetApiClient Transactions { get; }

    /// <summary>
    /// Single category
    /// Returns a single category. Amounts (budgeted, activity, balance, etc.) are specific to the current budget month (UTC).
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<CategoryResponse?> GetAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Update a category
    /// </summary>
    /// <param name="category">Category to update.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<SaveCategoryResponse> UpdateAsync(SaveCategory category, CancellationToken cancellationToken = default);
}