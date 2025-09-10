#pragma warning disable CA1043 // Use integral or string argument for indexers

using mmazur.YnabApiClient.V1.Models.Transactions;

namespace mmazur.YnabApiClient.V1.Interfaces.Transactions;

public interface IYnabV1ScheduledTransactionsApiClient
{
    IYnabV1ScheduledTransactionApiClient this[Guid scheduledTransactionId] { get; }

    /// <summary>
    /// List scheduled transactions
    /// Returns all scheduled transactions
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<ScheduledTransactionsResponse> GetAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// List scheduled transactions
    /// Returns all scheduled transactions
    /// </summary>
    /// <param name="lastKnowledgeOfServer">The starting server knowledge. If provided, only entities that have changed since last_knowledge_of_server will be included.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<ScheduledTransactionsResponse> GetAsync(long lastKnowledgeOfServer, CancellationToken cancellationToken = default);

    /// <summary>
    /// Create a single scheduled transaction
    /// Creates a single scheduled transaction(a transaction with a future date)
    /// </summary>
    /// <param name="scheduledTransaction">Scheduled transaction to create</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<ScheduledTransactionResponse> CreateAsync(SaveScheduledTransaction scheduledTransaction, CancellationToken cancellationToken = default);
}