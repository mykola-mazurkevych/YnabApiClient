using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Transactions.Models;

public sealed record TransactionsImportResponse
{
    [JsonConstructor]
    private TransactionsImportResponse()
    {
    }

    /// <summary>
    /// The list of transaction ids that were imported.
    /// </summary>
    [JsonPropertyName("transaction_ids")]
    [JsonRequired]
    public IReadOnlyList<string> TransactionIds { get; init; } = [];
}