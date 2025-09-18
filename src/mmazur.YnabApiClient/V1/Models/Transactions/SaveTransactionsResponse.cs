#pragma warning disable IDE0044 // Add readonly modifier

using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Transactions;

public sealed record SaveTransactionsResponse
{
    [JsonConstructor]
    private SaveTransactionsResponse()
    {
    }

    [JsonInclude]
    [JsonPropertyName("transaction_ids")]
    [JsonRequired]
    private List<string> _transactionIds = [];

    [JsonInclude]
    [JsonPropertyName("transactions")]
    [JsonRequired]
    private List<TransactionDetail> _transactions = [];

    [JsonInclude]
    [JsonPropertyName("duplicate_import_ids")]
    private List<string> _duplicateImportIds = [];

    /// <summary>
    /// The knowledge of the server
    /// </summary>
    [JsonPropertyName("server_knowledge")]
    [JsonRequired]
    public required long ServerKnowledge { get; init; }

    [JsonIgnore]
    public IReadOnlyList<string> TransactionIds => _transactionIds.AsReadOnly();

    [JsonIgnore]
    public IReadOnlyList<TransactionDetail> Transactions => _transactions.AsReadOnly();

    [JsonIgnore]
    public IReadOnlyList<string> DuplicateImportIds => _duplicateImportIds.AsReadOnly();
}