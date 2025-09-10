using mmazur.YnabApiClient.V1.Models.Transactions;

namespace mmazur.YnabApiClient.V1.Interfaces.Transactions;

public interface IYnabV1ScheduledTransactionApiClient
{
    /// <summary>
    /// Single scheduled transaction
    /// Returns a single scheduled transaction
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<ScheduledTransactionResponse> GetAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing scheduled transaction
    /// Updates a single scheduled transaction
    /// </summary>
    /// <param name="scheduledTransaction">The scheduled transaction to update</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<ScheduledTransactionResponse> UpdateAsync(SaveScheduledTransaction scheduledTransaction, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes an existing scheduled transaction
    /// Deletes a scheduled transaction
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<ScheduledTransactionResponse> DeleteAsync(CancellationToken cancellationToken = default);
}