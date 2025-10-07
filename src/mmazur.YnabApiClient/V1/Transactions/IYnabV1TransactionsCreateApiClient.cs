using mmazur.YnabApiClient.V1.Transactions.Models;

namespace mmazur.YnabApiClient.V1.Transactions;

public interface IYnabV1TransactionsCreateApiClient
{
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
}