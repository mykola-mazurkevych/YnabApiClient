using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Transactions;

public sealed record ScheduledTransactionResponse
{
    [JsonPropertyName("scheduled_transaction")]
    public ScheduledTransactionDetail? ScheduledTransaction { get; init; }
}