using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Transactions;

public sealed record TransactionResponse
{
    [JsonConstructor]
    private TransactionResponse()
    {
    }

    [JsonPropertyName("transaction")]
    [JsonRequired]
    public required TransactionDetail Transaction { get; init; }

    /// <summary>
    /// The knowledge of the server
    /// </summary>
    [JsonPropertyName("server_knowledge")]
    [JsonRequired]
    public required long ServerKnowledge { get; init; }
}