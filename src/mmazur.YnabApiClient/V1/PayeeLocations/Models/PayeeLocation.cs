using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.PayeeLocations.Models;

public sealed record PayeeLocation
{
    [JsonPropertyName("id")]
    [JsonRequired]
    public required Guid Id { get; init; }

    [JsonPropertyName("payee_id")]
    [JsonRequired]
    public required Guid PayeeId { get; init; }

    [JsonPropertyName("latitude")]
    [JsonRequired]
    public required double Latitude { get; init; }

    [JsonPropertyName("longitude")]
    [JsonRequired]
    public required double Longitude { get; init; }

    /// <summary>
    /// Whether the payee location has been deleted. Deleted payee locations will only be included in delta requests
    /// </summary>
    [JsonPropertyName("deleted")]
    [JsonRequired]
    public required bool Deleted { get; init; }
}