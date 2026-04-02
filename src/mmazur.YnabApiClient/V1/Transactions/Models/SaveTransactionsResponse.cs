using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Transactions.Models;

public sealed record SaveTransactionsResponse
{
    [JsonConstructor]
    private SaveTransactionsResponse()
    {
    }

    [JsonPropertyName("transaction_ids")]
    [JsonRequired]
    public IReadOnlyList<string> TransactionIds { get; init; } = [];

    [JsonPropertyName("transactions")]
    [JsonRequired]
    public IReadOnlyList<TransactionDetail> Transactions { get; init; } = [];

    [JsonPropertyName("duplicate_import_ids")]
    public IReadOnlyList<string> DuplicateImportIds { get; init; } = [];

    /// <summary>
    /// The knowledge of the server
    /// </summary>
    [JsonPropertyName("server_knowledge")]
    [JsonRequired]
    public required long ServerKnowledge { get; init; }

}