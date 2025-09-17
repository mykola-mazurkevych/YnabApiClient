#pragma warning disable IDE0044 // Add readonly modifier

using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Transactions;

public sealed record SaveTransactionsResponse
{
    [JsonInclude]
    [JsonPropertyName("transaction_ids")]
    private List<string> _transactionIds = [];

    [JsonInclude]
    [JsonPropertyName("transactions")]
    private List<TransactionDetail> _transactions = [];

    /// <summary>
    /// The knowledge of the server
    /// </summary>
    [JsonPropertyName("server_knowledge")]
    public long ServerKnowledge { get; init; }

    public IReadOnlyList<string> TransactionIds => _transactionIds.AsReadOnly();

    public IReadOnlyList<TransactionDetail> Transactions => _transactions.AsReadOnly();
}