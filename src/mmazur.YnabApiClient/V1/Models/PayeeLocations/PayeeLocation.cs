using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.PayeeLocations;

public sealed record PayeeLocation
{
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }

    [JsonPropertyName("payee_id")]
    public required Guid PayeeId { get; init; }

    [JsonPropertyName("latitude")]
    public required string Latitude { get; init; }

    [JsonPropertyName("longitude")]
    public required string Longitude { get; init; }

    [JsonPropertyName("deleted")]
    public required bool Deleted { get; init; }
}