using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Payees.Models;

public sealed record PayeesResponse
{
    [JsonPropertyName("payees")]
    [JsonRequired]
    public IReadOnlyList<Payee> Payees { get; init; } = [];

    /// <summary>
    /// The knowledge of the server
    /// </summary>
    [JsonPropertyName("server_knowledge")]
    [JsonRequired]
    public required long ServerKnowledge { get; init; }
}