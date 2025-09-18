using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Transactions;

public sealed record ScheduledTransactionResponse
{
    [JsonConstructor]
    private ScheduledTransactionResponse()
    {
    }

    [JsonPropertyName("scheduled_transaction")]
    [JsonRequired]
    public required ScheduledTransactionDetail ScheduledTransaction { get; init; }
}