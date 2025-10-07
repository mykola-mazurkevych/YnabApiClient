using mmazur.YnabApiClient.V1.Transactions.Models;

namespace mmazur.YnabApiClient.V1.Transactions;

public interface IYnabV1ScheduledTransactionsGetApiClient
{
    /// <summary>
    /// List scheduled transactions
    /// Returns all scheduled transactions
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<ScheduledTransactionsResponse?> GetAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// List scheduled transactions
    /// Returns all scheduled transactions
    /// </summary>
    /// <param name="lastKnowledgeOfServer">The starting server knowledge. If provided, only entities that have changed since last_knowledge_of_server will be included.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<ScheduledTransactionsResponse?> GetAsync(long lastKnowledgeOfServer, CancellationToken cancellationToken = default);
}