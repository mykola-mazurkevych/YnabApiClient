using mmazur.YnabApiClient.V1.Transactions.Models;

namespace mmazur.YnabApiClient.V1.Transactions;

public interface IYnabV1ScheduledTransactionsCreateApiClient
{
    /// <summary>
    /// Create a single scheduled transaction
    /// Creates a single scheduled transaction(a transaction with a future date)
    /// </summary>
    /// <param name="scheduledTransaction">Scheduled transaction to create</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<ScheduledTransactionResponse> CreateAsync(SaveScheduledTransaction scheduledTransaction, CancellationToken cancellationToken = default);
}