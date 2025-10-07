using mmazur.YnabApiClient.V1.Categories.Models;

namespace mmazur.YnabApiClient.V1.Categories;

public interface IYnabV1CategoryGetApiClient
{
    /// <summary>
    /// Single category
    /// Returns a single category. Amounts (budgeted, activity, balance, etc.) are specific to the current budget month (UTC).
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<CategoryResponse?> GetAsync(CancellationToken cancellationToken = default);
}