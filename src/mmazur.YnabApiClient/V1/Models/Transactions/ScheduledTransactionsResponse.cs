#pragma warning disable IDE0044 // Add readonly modifier

using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Transactions;

public sealed record ScheduledTransactionsResponse
{
    [JsonInclude]
    [JsonPropertyName("scheduled_transactions")]
    private List<ScheduledTransactionDetail> _scheduledTransactions = [];

    /// <summary>
    /// The knowledge of the server
    /// </summary>
    [JsonPropertyName("server_knowledge")]
    public required long ServerKnowledge { get; init; }

    public IReadOnlyList<ScheduledTransactionDetail> ScheduledTransactions => _scheduledTransactions.AsReadOnly();
}