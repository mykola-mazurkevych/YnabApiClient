using mmazur.YnabApiClient.V1.PayeeLocations.Models;

namespace mmazur.YnabApiClient.V1.PayeeLocations;

public interface IYnabV1PayeeLocationsApiClient
{
    IYnabV1PayeeLocationApiClient this[Guid payeeLocationId] { get; }

    /// <summary>
    /// List payee locations
    /// Returns all payee locations
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<PayeeLocationsResponse?> GetAsync(CancellationToken cancellationToken = default);
}