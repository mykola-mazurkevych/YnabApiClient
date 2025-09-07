using mmazur.YnabApiClient.V1.Models.Payees;

namespace mmazur.YnabApiClient.V1.Interfaces.Payees;

public interface IYnabV1PayeeApiClient
{
    /// <summary>
    /// Single payee
    /// Returns a single payee
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<PayeeResponse> GetAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Update a payee
    /// </summary>
    /// <param name="payee">Payee to update</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<PayeeResponse> UpdateAsync(UpdatePayee payee, CancellationToken cancellationToken = default);
}