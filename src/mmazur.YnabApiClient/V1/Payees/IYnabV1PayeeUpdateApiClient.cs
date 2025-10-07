using mmazur.YnabApiClient.V1.Payees.Models;

namespace mmazur.YnabApiClient.V1.Payees;

public interface IYnabV1PayeeUpdateApiClient
{
    /// <summary>
    /// Update a payee
    /// </summary>
    /// <param name="payee">Payee to update</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<SavePayeeResponse> UpdateAsync(SavePayee payee, CancellationToken cancellationToken = default);
}