using mmazur.YnabApiClient.V1.Transactions.Models;

namespace mmazur.YnabApiClient.V1.Transactions;

public interface IYnabV1ScheduledTransactionDeleteApiClient
{
    /// <summary>
    /// Deletes an existing scheduled transaction
    /// Deletes a scheduled transaction
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<ScheduledTransactionResponse> DeleteAsync(CancellationToken cancellationToken = default);
}