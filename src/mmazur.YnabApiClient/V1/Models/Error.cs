using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models;

internal sealed record Error
{
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("detail")]
    public required string Detail { get; init; }
}