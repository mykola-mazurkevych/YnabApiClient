using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Transactions.Models;

public sealed record TransactionsResponse
{
    [JsonConstructor]
    private TransactionsResponse()
    {
    }

    [JsonPropertyName("transactions")]
    [JsonRequired]
    public IReadOnlyList<TransactionDetail> Transactions { get; init; } = [];

    /// <summary>
    /// The knowledge of the server
    /// </summary>
    [JsonPropertyName("server_knowledge")]
    [JsonRequired]
    public required long ServerKnowledge { get; init; }

}