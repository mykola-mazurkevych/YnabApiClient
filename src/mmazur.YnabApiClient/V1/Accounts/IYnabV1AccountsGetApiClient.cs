using mmazur.YnabApiClient.V1.Accounts.Models;

namespace mmazur.YnabApiClient.V1.Accounts;

public interface IYnabV1AccountsGetApiClient
{
    /// <summary>
    /// Accounts list
    /// Returns all accounts
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<AccountsResponse?> GetAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Accounts list
    /// Returns all accounts
    /// </summary>
    /// <param name="lastKnowledgeOfServer">The starting server knowledge. If provided, only entities that have changed since lastKnowledgeOfServer will be included.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<AccountsResponse?> GetAsync(long lastKnowledgeOfServer, CancellationToken cancellationToken = default);
}