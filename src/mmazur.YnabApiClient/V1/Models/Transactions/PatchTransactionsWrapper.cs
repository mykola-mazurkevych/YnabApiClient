using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Transactions;

internal sealed record PatchTransactionsWrapper
{
    [JsonPropertyName("transactions")]
    public required IEnumerable<SaveTransactionWithIdOrImportId> Transactions { get; init; }
}