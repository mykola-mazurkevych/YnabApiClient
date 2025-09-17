using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Transactions;

internal sealed record PutTransactionWrapper
{
    [JsonPropertyName("transaction")]
    public required ExistingTransaction Transaction { get; init; }
}