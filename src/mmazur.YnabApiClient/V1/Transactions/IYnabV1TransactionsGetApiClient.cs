using mmazur.YnabApiClient.V1.Transactions.Models;

namespace mmazur.YnabApiClient.V1.Transactions;

public interface IYnabV1TransactionsGetApiClient
{
    /// <summary>
    /// List transactions
    /// Returns budget transactions, excluding any pending transactions
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<TransactionsResponse?> GetAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// List transactions
    /// Returns budget transactions, excluding any pending transactions
    /// </summary>
    /// <param name="sinceDate">Only transactions on or after this date will be included. The date should be ISO formatted (e.g. 2016-12-30).</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<TransactionsResponse?> GetAsync(DateOnly sinceDate, CancellationToken cancellationToken = default);

    /// <summary>
    /// List transactions
    /// Returns budget transactions, excluding any pending transactions
    /// </summary>
    /// <param name="sinceDate">Only transactions on or after this date will be included. The date should be ISO formatted (e.g. 2016-12-30).</param>
    /// <param name="type">Only transactions of the specified type will be included. "uncategorized" and "unapproved" are currently supported.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<TransactionsResponse?> GetAsync(DateOnly sinceDate, TransactionType type, CancellationToken cancellationToken = default);

    /// <summary>
    /// List transactions
    /// Returns budget transactions, excluding any pending transactions
    /// </summary>
    /// <param name="sinceDate">Only transactions on or after this date will be included. The date should be ISO formatted (e.g. 2016-12-30).</param>
    /// <param name="lastKnowledgeOfServer">The starting server knowledge. If provided, only entities that have changed since last_knowledge_of_server will be included.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<TransactionsResponse?> GetAsync(DateOnly sinceDate, long lastKnowledgeOfServer, CancellationToken cancellationToken = default);

    /// <summary>
    /// List transactions
    /// Returns budget transactions, excluding any pending transactions
    /// </summary>
    /// <param name="sinceDate">Only transactions on or after this date will be included. The date should be ISO formatted (e.g. 2016-12-30).</param>
    /// <param name="type">Only transactions of the specified type will be included. "uncategorized" and "unapproved" are currently supported.</param>
    /// <param name="lastKnowledgeOfServer">The starting server knowledge. If provided, only entities that have changed since last_knowledge_of_server will be included.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<TransactionsResponse?> GetAsync(DateOnly sinceDate, TransactionType type, long lastKnowledgeOfServer, CancellationToken cancellationToken = default);

    /// <summary>
    /// List transactions
    /// Returns budget transactions, excluding any pending transactions
    /// </summary>
    /// <param name="type">Only transactions of the specified type will be included. "uncategorized" and "unapproved" are currently supported.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<TransactionsResponse?> GetAsync(TransactionType type, CancellationToken cancellationToken = default);

    /// <summary>
    /// List transactions
    /// Returns budget transactions, excluding any pending transactions
    /// </summary>
    /// <param name="type">Only transactions of the specified type will be included. "uncategorized" and "unapproved" are currently supported.</param>
    /// <param name="lastKnowledgeOfServer">The starting server knowledge. If provided, only entities that have changed since last_knowledge_of_server will be included.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<TransactionsResponse?> GetAsync(TransactionType type, long lastKnowledgeOfServer, CancellationToken cancellationToken = default);

    /// <summary>
    /// List transactions
    /// Returns budget transactions, excluding any pending transactions
    /// </summary>
    /// <param name="lastKnowledgeOfServer">The starting server knowledge. If provided, only entities that have changed since last_knowledge_of_server will be included.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<TransactionsResponse?> GetAsync(long lastKnowledgeOfServer, CancellationToken cancellationToken = default);
}