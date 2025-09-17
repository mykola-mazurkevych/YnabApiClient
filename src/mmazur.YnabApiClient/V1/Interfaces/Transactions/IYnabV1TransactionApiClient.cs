using mmazur.YnabApiClient.V1.Models.Transactions;

namespace mmazur.YnabApiClient.V1.Interfaces.Transactions;

public interface IYnabV1TransactionApiClient
{
    /// <summary>
    /// Single transaction
    /// Returns a single transaction
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<TransactionResponse> GetAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing transaction
    /// Updates a single transaction
    /// </summary>
    /// <param name="transaction"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<TransactionResponse> UpdateAsync(ExistingTransaction transaction, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes an existing transaction
    /// Deletes a transaction
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<TransactionResponse> DeleteAsync(CancellationToken cancellationToken = default);
}