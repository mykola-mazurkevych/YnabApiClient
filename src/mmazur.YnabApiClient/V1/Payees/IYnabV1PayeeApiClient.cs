using mmazur.YnabApiClient.V1.PayeeLocations;
using mmazur.YnabApiClient.V1.Payees.Models;
using mmazur.YnabApiClient.V1.Transactions;

namespace mmazur.YnabApiClient.V1.Payees;

public interface IYnabV1PayeeApiClient
{
    IYnabV1PayeeLocationsApiClient Locations { get; }
    IYnabV1TransactionsApiClient Transactions { get; }

    /// <summary>
    /// Single payee
    /// Returns a single payee
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<PayeeResponse?> GetAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Update a payee
    /// </summary>
    /// <param name="payee">Payee to update</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<SavePayeeResponse> UpdateAsync(SavePayee payee, CancellationToken cancellationToken = default);
}