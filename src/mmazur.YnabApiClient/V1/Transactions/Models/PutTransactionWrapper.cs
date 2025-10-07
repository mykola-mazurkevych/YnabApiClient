using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Transactions.Models;

internal sealed record PutTransactionWrapper
{
    [JsonPropertyName("transaction")]
    public required ExistingTransaction Transaction { get; init; }
}