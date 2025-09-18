#pragma warning disable IDE0044 // Add readonly modifier

using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Payees;

public sealed record PayeesResponse
{
    [JsonInclude]
    [JsonPropertyName("payees")]
    [JsonRequired]
    private List<Payee> _payees = [];

    /// <summary>
    /// The knowledge of the server
    /// </summary>
    [JsonPropertyName("server_knowledge")]
    [JsonRequired]
    public required long ServerKnowledge { get; init; }

    [JsonIgnore]
    public IReadOnlyList<Payee> Payees => _payees.AsReadOnly();
}