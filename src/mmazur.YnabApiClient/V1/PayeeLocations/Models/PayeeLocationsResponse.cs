using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.PayeeLocations.Models;

public sealed record PayeeLocationsResponse
{
    [JsonConstructor]
    private PayeeLocationsResponse()
    {
    }

    [JsonPropertyName("payee_locations")]
    [JsonRequired]
    public IReadOnlyList<PayeeLocation> PayeeLocations { get; init; } = [];
}