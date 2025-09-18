using mmazur.YnabApiClient.V1.Models.Transactions;

namespace mmazur.YnabApiClient.V1.Interfaces.Transactions;

public interface IYnabV1TransactionsApiClient
{
    IYnabV1TransactionApiClient this[string transactionsId] { get; }

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

    /// <summary>
    /// Create a single transaction
    /// Creates a single transaction
    /// </summary>
    /// <param name="transaction">The transaction to create</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<SaveTransactionResponse> CreateAsync(NewTransaction transaction, CancellationToken cancellationToken = default);

    /// <summary>
    /// Create multiple transactions
    /// Creates multiple transactions
    /// </summary>
    /// <param name="transactions">Transactions to create</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<SaveTransactionsResponse> CreateAsync(IEnumerable<NewTransaction> transactions, CancellationToken cancellationToken = default);

    /// <summary>
    /// Update single transaction
    /// Updates single transactions, by id or import_id.
    /// </summary>
    /// <param name="transaction">
    /// The transaction to update.
    /// The transaction must have either an id or import_id specified.
    /// If id is specified as null an import_id value can be provided which will allow transaction(s) to be updated by its import_id.
    /// If an id is specified, it will always be used for lookup.
    /// You should not specify both id and import_id.
    /// Updating an import_id on an existing transaction is not allowed; if an import_id is specified, it will only be used to look up the transaction.
    /// </param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<SaveTransactionResponse> UpdateAsync(SaveTransactionWithIdOrImportId transaction, CancellationToken cancellationToken = default);

    /// <summary>
    /// Update multiple transactions
    /// Updates multiple transactions, by id or import_id.
    /// </summary>
    /// <param name="transactions">
    /// The transactions to update.
    /// Each transaction must have either an id or import_id specified.
    /// If id is specified as null an import_id value can be provided which will allow transaction(s) to be updated by its import_id.
    /// If an id is specified, it will always be used for lookup.
    /// You should not specify both id and import_id.
    /// Updating an import_id on an existing transaction is not allowed; if an import_id is specified, it will only be used to look up the transaction.
    /// </param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<SaveTransactionsResponse> UpdateAsync(IEnumerable<SaveTransactionWithIdOrImportId> transactions, CancellationToken cancellationToken = default);

    /// <summary>
    /// Import transactions
    /// Imports available transactions on all linked accounts for the given budget.
    /// Linked accounts allow transactions to be imported directly from a specified financial institution and this endpoint initiates that import.
    /// Sending a request to this endpoint is the equivalent of clicking "Import" on each account in the web application or tapping the "New Transactions" banner in the mobile applications.
    /// The response for this endpoint contains the transaction ids that have been imported.
    /// </summary>
    /// <param name="transactions"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<TransactionsImportResponse> ImportAsync(IEnumerable<object> transactions, CancellationToken cancellationToken = default); // TODO: Investigate data to be sent (collection of transactions, file, etc.)
}