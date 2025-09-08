using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models;

internal sealed record ErrorResponse
{
    [JsonPropertyName("error")]
    public required ErrorDetail Error { get; init; }
}