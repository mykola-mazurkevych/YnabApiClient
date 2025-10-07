using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Transactions.Models;

internal sealed record PatchTransactionsWrapper
{
    [JsonPropertyName("transactions")]
    public required IEnumerable<SaveTransactionWithIdOrImportId> Transactions { get; init; }
}