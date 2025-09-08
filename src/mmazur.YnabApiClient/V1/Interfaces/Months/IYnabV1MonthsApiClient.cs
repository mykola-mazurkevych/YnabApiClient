#pragma warning disable CA1043 // Use integral or string argument for indexers

using mmazur.YnabApiClient.V1.Models.Months;

namespace mmazur.YnabApiClient.V1.Interfaces.Months;

public interface IYnabV1MonthsApiClient
{
    IYnabV1MonthApiClient this[DateOnly month] { get; }

    /// <summary>
    /// List budget months
    /// Returns all budget months
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<MonthsResponse> GetAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// List budget months
    /// Returns all budget months
    /// </summary>
    /// <param name="lastKnowledgeOfServer">The starting server knowledge. If provided, only entities that have changed since last_knowledge_of_server will be included.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<MonthsResponse> GetAsync(long lastKnowledgeOfServer, CancellationToken cancellationToken = default);
}