using mmazur.YnabApiClient.V1.Payees.Models;

namespace mmazur.YnabApiClient.V1.Payees;

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