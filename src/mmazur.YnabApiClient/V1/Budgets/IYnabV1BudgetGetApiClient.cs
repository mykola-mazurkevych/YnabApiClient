using mmazur.YnabApiClient.V1.Budgets.Models;

namespace mmazur.YnabApiClient.V1.Budgets;

public interface IYnabV1BudgetGetApiClient
{
    /// <summary>
    /// Returns a single budget with all related entities. This resource is effectively a full budget export.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<BudgetDetailResponse?> GetAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a single budget with all related entities. This resource is effectively a full budget export.
    /// </summary>
    /// <param name="lastKnowledgeOfServer">The starting server knowledge. If provided, only entities that have changed since last_knowledge_of_server will be included.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<BudgetDetailResponse?> GetAsync(long lastKnowledgeOfServer, CancellationToken cancellationToken = default);
}