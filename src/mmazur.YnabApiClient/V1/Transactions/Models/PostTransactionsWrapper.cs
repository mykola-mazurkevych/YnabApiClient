using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Transactions.Models;

internal sealed record PostTransactionsWrapper
{
    [JsonPropertyName("transactions")]
    public required IEnumerable<NewTransaction> Transactions { get; init; }
}