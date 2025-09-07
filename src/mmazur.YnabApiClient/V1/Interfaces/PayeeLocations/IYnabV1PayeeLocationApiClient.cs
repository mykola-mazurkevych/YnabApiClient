using mmazur.YnabApiClient.V1.Models.PayeeLocations;

namespace mmazur.YnabApiClient.V1.Interfaces.PayeeLocations;

public interface IYnabV1PayeeLocationApiClient
{
    /// <summary>
    /// Single payee location
    /// Returns a single payee location
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<PayeeLocationResponse> GetAsync(CancellationToken cancellationToken = default);
}