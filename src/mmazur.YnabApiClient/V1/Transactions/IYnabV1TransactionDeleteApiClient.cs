using mmazur.YnabApiClient.V1.Transactions.Models;

namespace mmazur.YnabApiClient.V1.Transactions;

public interface IYnabV1TransactionDeleteApiClient
{
    /// <summary>
    /// Deletes an existing transaction
    /// Deletes a transaction
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<TransactionResponse> DeleteAsync(CancellationToken cancellationToken = default);
}