using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models;

internal sealed record ErrorDetail
{
    [JsonConstructor]
    private ErrorDetail()
    {
    }

    [JsonPropertyName("id")]
    [JsonRequired]
    public required string Id { get; init; }

    [JsonPropertyName("name")]
    [JsonRequired]
    public required string Name { get; init; }

    [JsonPropertyName("detail")]
    [JsonRequired]
    public required string Detail { get; init; }
}