using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Transactions.Models;

public sealed record ScheduledTransactionsResponse
{
    [JsonConstructor]
    private ScheduledTransactionsResponse()
    {
    }

    [JsonPropertyName("scheduled_transactions")]
    [JsonRequired]
    public IReadOnlyList<ScheduledTransactionDetail> ScheduledTransactions { get; init; } = [];

    /// <summary>
    /// The knowledge of the server
    /// </summary>
    [JsonPropertyName("server_knowledge")]
    [JsonRequired]
    public required long ServerKnowledge { get; init; }

}