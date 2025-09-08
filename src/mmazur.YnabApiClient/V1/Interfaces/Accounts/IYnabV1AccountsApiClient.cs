#pragma warning disable CA1043 // Use integral or string argument for indexers

using mmazur.YnabApiClient.V1.Models.Accounts;

namespace mmazur.YnabApiClient.V1.Interfaces.Accounts;

public interface IYnabV1AccountsApiClient
{
    IYnabV1AccountApiClient this[Guid accountId] { get; }

    /// <summary>
    /// Accounts list
    /// Returns all accounts
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<AccountsResponse> GetAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Accounts list
    /// Returns all accounts
    /// </summary>
    /// <param name="lastKnowledgeOfServer">The starting server knowledge. If provided, only entities that have changed since lastKnowledgeOfServer will be included.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<AccountsResponse> GetAsync(long lastKnowledgeOfServer, CancellationToken cancellationToken = default);

    /// <summary>
    /// Create a new account
    /// Creates a new account
    /// </summary>
    /// <param name="account">The account to create.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<AccountResponse> CreateAsync(SaveAccount account, CancellationToken cancellationToken = default);
}