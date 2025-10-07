using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Transactions.Models;

internal sealed record PostTransactionsWrapper
{
    [JsonPropertyName("transaction")]
    public NewTransaction? Transaction { get; init; }

    [JsonPropertyName("transactions")]
    public IEnumerable<NewTransaction>? Transactions { get; init; }
}