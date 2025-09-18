#pragma warning disable CA1043 // Use integral or string argument for indexers

using mmazur.YnabApiClient.V1.Models.Payees;

namespace mmazur.YnabApiClient.V1.Interfaces.Payees;

public interface IYnabV1PayeesApiClient
{
    IYnabV1PayeeApiClient this[Guid payeeId] { get; }

    /// <summary>
    /// List payees
    /// Returns all payees
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<PayeesResponse?> GetAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// List payees
    /// Returns all payees
    /// </summary>
    /// <param name="lastKnowledgeOfServer">The starting server knowledge. If provided, only entities that have changed since lastKnowledgeOfServer will be included.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<PayeesResponse?> GetAsync(long lastKnowledgeOfServer, CancellationToken cancellationToken = default);
}