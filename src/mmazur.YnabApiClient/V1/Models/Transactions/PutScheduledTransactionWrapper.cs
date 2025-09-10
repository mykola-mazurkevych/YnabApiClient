using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Transactions;

internal sealed record PutScheduledTransactionWrapper
{
    [JsonPropertyName("scheduled_transaction")]
    public required SaveScheduledTransaction ScheduledTransaction { get; init; }
}