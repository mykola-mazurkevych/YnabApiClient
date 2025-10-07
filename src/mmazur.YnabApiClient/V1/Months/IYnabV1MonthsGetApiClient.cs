using mmazur.YnabApiClient.V1.Months.Models;

namespace mmazur.YnabApiClient.V1.Months;

public interface IYnabV1MonthsGetApiClient
{
    /// <summary>
    /// List budget months
    /// Returns all budget months
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<MonthSummariesResponse?> GetAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// List budget months
    /// Returns all budget months
    /// </summary>
    /// <param name="lastKnowledgeOfServer">The starting server knowledge. If provided, only entities that have changed since last_knowledge_of_server will be included.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<MonthSummariesResponse?> GetAsync(long lastKnowledgeOfServer, CancellationToken cancellationToken = default);
}