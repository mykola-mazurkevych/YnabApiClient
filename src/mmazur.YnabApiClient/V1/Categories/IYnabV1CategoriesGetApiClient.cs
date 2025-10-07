using mmazur.YnabApiClient.V1.Categories.Models;

namespace mmazur.YnabApiClient.V1.Categories;

public interface IYnabV1CategoriesGetApiClient
{
    /// <summary>
    /// List categories
    /// Returns all categories grouped by category group. Amounts (budgeted, activity, balance, etc.) are specific to the current budget month (UTC).
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<CategoriesResponse?> GetAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// List categories
    /// Returns all categories grouped by category group. Amounts (budgeted, activity, balance, etc.) are specific to the current budget month (UTC).
    /// </summary>
    /// <param name="lastKnowledgeOfServer">The starting server knowledge. If provided, only entities that have changed since last_knowledge_of_server will be included.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<CategoriesResponse?> GetAsync(long lastKnowledgeOfServer, CancellationToken cancellationToken = default);
}