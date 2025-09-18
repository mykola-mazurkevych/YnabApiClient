#pragma warning disable IDE0044 // Add readonly modifier

using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Transactions;

public sealed record SaveTransactionResponse
{
    [JsonInclude]
    [JsonPropertyName("transaction_ids")]
    private List<string> _transactionIds = [];

    [JsonPropertyName("transaction")]
    public required TransactionDetail Transaction { get; init; }

    /// <summary>
    /// The knowledge of the server
    /// </summary>
    [JsonPropertyName("server_knowledge")]
    public required long ServerKnowledge { get; init; }

    public IReadOnlyList<string> TransactionIds => _transactionIds.AsReadOnly();
}