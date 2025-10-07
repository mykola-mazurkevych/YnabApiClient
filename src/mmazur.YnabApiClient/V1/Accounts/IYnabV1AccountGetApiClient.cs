using mmazur.YnabApiClient.V1.Accounts.Models;

namespace mmazur.YnabApiClient.V1.Accounts;

public interface IYnabV1AccountGetApiClient
{
    /// <summary>
    /// Single account
    /// Returns a single account
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<AccountResponse?> GetAsync(CancellationToken cancellationToken = default);
}