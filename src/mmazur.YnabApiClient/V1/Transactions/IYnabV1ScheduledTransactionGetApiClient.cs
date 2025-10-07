using mmazur.YnabApiClient.V1.Transactions.Models;

namespace mmazur.YnabApiClient.V1.Transactions;

public interface IYnabV1ScheduledTransactionGetApiClient
{
    /// <summary>
    /// Single scheduled transaction
    /// Returns a single scheduled transaction
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<ScheduledTransactionResponse?> GetAsync(CancellationToken cancellationToken = default);
}