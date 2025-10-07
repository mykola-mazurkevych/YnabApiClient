using mmazur.YnabApiClient.V1.Transactions.Models;

namespace mmazur.YnabApiClient.V1.Transactions;

public interface IYnabV1TransactionUpdateApiClient
{
    /// <summary>
    /// Updates an existing transaction
    /// Updates a single transaction
    /// </summary>
    /// <param name="transaction"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<TransactionResponse> UpdateAsync(ExistingTransaction transaction, CancellationToken cancellationToken = default);
}