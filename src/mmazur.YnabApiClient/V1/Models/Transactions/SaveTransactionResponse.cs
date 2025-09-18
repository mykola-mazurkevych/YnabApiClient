#pragma warning disable IDE0044 // Add readonly modifier

using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Transactions;

public sealed record SaveTransactionResponse
{
    [JsonConstructor]
    private SaveTransactionResponse()
    {
    }

    [JsonInclude]
    [JsonPropertyName("transaction_ids")]
    [JsonRequired]
    private List<string> _transactionIds = [];

    [JsonInclude]
    [JsonPropertyName("duplicate_import_ids")]
    private List<string> _duplicateImportIds = [];

    [JsonPropertyName("transaction")]
    [JsonRequired]
    public required TransactionDetail Transaction { get; init; }

    /// <summary>
    /// The knowledge of the server
    /// </summary>
    [JsonPropertyName("server_knowledge")]
    public required long ServerKnowledge { get; init; }

    [JsonIgnore]
    public IReadOnlyList<string> TransactionIds => _transactionIds.AsReadOnly();

    [JsonIgnore]
    public IReadOnlyList<string> DuplicateImportIds => _duplicateImportIds.AsReadOnly();
}