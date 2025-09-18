#pragma warning disable IDE0044 // Add readonly modifier

using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Transactions;

public sealed record TransactionsResponse
{
    [JsonInclude]
    [JsonPropertyName("transactions")]
    private List<TransactionDetail> _transactions = [];

    /// <summary>
    /// The knowledge of the server
    /// </summary>
    [JsonPropertyName("server_knowledge")]
    public required long ServerKnowledge { get; init; }

    public IReadOnlyList<TransactionDetail> Transactions => _transactions.AsReadOnly();
}