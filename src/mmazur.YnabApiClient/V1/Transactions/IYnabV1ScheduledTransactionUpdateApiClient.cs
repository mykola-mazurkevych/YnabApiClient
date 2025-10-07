using mmazur.YnabApiClient.V1.Transactions.Models;

namespace mmazur.YnabApiClient.V1.Transactions;

public interface IYnabV1ScheduledTransactionUpdateApiClient
{
    /// <summary>
    /// Updates an existing scheduled transaction
    /// Updates a single scheduled transaction
    /// </summary>
    /// <param name="scheduledTransaction">The scheduled transaction to update</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<ScheduledTransactionResponse> UpdateAsync(SaveScheduledTransaction scheduledTransaction, CancellationToken cancellationToken = default);
}