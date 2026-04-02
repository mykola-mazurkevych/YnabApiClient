using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Transactions.Models;

internal sealed record PostTransactionWrapper
{
    [JsonPropertyName("transaction")]
    public required NewTransaction Transaction { get; init; }
}