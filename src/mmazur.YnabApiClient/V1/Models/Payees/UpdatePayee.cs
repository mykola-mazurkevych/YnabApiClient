using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Payees;

public sealed record UpdatePayee
{
    [JsonPropertyName("name")]
    public required string Name { get; init; }
}