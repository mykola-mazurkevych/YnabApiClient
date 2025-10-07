using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.PayeeLocations.Models;

public sealed record PayeeLocationResponse
{
    [JsonConstructor]
    private PayeeLocationResponse()
    {
    }

    [JsonPropertyName("payee_location")]
    [JsonRequired]
    public required PayeeLocation PayeeLocation { get; init; }
}