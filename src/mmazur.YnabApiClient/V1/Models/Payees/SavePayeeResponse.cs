using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Payees;

public sealed record SavePayeeResponse
{
    [JsonPropertyName("payee")]
    public Payee? Payee { get; init; }

    /// <summary>
    /// The knowledge of the server
    /// </summary>
    [JsonPropertyName("server_knowledge")]
    public long ServerKnowledge { get; init; }
}