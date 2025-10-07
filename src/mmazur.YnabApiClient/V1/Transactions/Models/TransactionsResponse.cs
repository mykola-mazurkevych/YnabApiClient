#pragma warning disable IDE0044 // Add readonly modifier

using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Transactions.Models;

public sealed record TransactionsResponse
{
    [JsonConstructor]
    private TransactionsResponse()
    {
    }

    [JsonInclude]
    [JsonPropertyName("transactions")]
    [JsonRequired]
    private List<TransactionDetail> _transactions = [];

    /// <summary>
    /// The knowledge of the server
    /// </summary>
    [JsonPropertyName("server_knowledge")]
    [JsonRequired]
    public required long ServerKnowledge { get; init; }

    [JsonIgnore]
    public IReadOnlyList<TransactionDetail> Transactions => _transactions.AsReadOnly();
}