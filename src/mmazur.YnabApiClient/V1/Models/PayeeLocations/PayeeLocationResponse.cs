using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.PayeeLocations;

public sealed record PayeeLocationResponse
{
    [JsonPropertyName("payee_location")]
    public PayeeLocation? PayeeLocation { get; init; }
}