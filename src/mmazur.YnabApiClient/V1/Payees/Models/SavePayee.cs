using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Payees.Models;

public sealed record SavePayee
{
    [JsonPropertyName("name")]
    public required string Name { get; init; }
}