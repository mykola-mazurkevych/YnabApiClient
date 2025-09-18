using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models;

internal sealed record ErrorResponse
{
    [JsonConstructor]
    private ErrorResponse()
    {
    }

    [JsonPropertyName("error")]
    [JsonRequired]
    public required ErrorDetail Error { get; init; }
}