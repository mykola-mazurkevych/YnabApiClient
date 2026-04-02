using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Transactions.Models;

public sealed record SaveTransactionResponse
{
    [JsonConstructor]
    private SaveTransactionResponse()
    {
    }

    [JsonPropertyName("transaction_ids")]
    [JsonRequired]
    public IReadOnlyList<string> TransactionIds { get; init; } = [];

    [JsonPropertyName("duplicate_import_ids")]
    public IReadOnlyList<string> DuplicateImportIds { get; init; } = [];

    [JsonPropertyName("transaction")]
    [JsonRequired]
    public required TransactionDetail Transaction { get; init; }

    /// <summary>
    /// The knowledge of the server
    /// </summary>
    [JsonPropertyName("server_knowledge")]
    public required long ServerKnowledge { get; init; }

}