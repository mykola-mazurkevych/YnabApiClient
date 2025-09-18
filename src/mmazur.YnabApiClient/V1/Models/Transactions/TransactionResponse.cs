using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Transactions;

public sealed record TransactionResponse
{
    [JsonPropertyName("transaction")]
    public required TransactionDetail Transaction { get; init; }

    /// <summary>
    /// The knowledge of the server
    /// </summary>
    [JsonPropertyName("server_knowledge")]
    public required long ServerKnowledge { get; init; }
}