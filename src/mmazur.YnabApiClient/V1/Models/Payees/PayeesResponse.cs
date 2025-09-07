#pragma warning disable IDE0044 // Add readonly modifier

using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Payees;

public sealed record PayeesResponse
{
    [JsonInclude]
    [JsonPropertyName("payees")]
    private List<Payee> _payees = [];

    public IReadOnlyList<Payee> Payees => _payees.AsReadOnly();

    [JsonPropertyName("server_knowledge")]
    public long ServerKnowledge { get; init; }
}