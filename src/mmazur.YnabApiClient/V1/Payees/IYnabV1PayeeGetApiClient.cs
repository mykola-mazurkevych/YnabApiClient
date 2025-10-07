using mmazur.YnabApiClient.V1.Payees.Models;

namespace mmazur.YnabApiClient.V1.Payees;

public interface IYnabV1PayeeGetApiClient
{
    /// <summary>
    /// Single payee
    /// Returns a single payee
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<PayeeResponse?> GetAsync(CancellationToken cancellationToken = default);
}