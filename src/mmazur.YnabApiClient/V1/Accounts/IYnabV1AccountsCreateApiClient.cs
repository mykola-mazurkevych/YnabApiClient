using mmazur.YnabApiClient.V1.Accounts.Models;

namespace mmazur.YnabApiClient.V1.Accounts;

public interface IYnabV1AccountsCreateApiClient
{
    /// <summary>
    /// Create a new account
    /// Creates a new account
    /// </summary>
    /// <param name="account">The account to create.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<AccountResponse> CreateAsync(SaveAccount account, CancellationToken cancellationToken = default);
}