using mmazur.YnabApiClient.V1.Transactions.Models;

namespace mmazur.YnabApiClient.V1.Transactions;

public interface IYnabV1TransactionGetApiClient
{
    /// <summary>
    /// Single transaction
    /// Returns a single transaction
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<TransactionResponse?> GetAsync(CancellationToken cancellationToken = default);
}