using mmazur.YnabApiClient.V1.PayeeLocations.Models;

namespace mmazur.YnabApiClient.V1.PayeeLocations;

public interface IYnabV1PayeeLocationGetApiClient
{
    /// <summary>
    /// Single payee location
    /// Returns a single payee location
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<PayeeLocationResponse?> GetAsync(CancellationToken cancellationToken = default);
}