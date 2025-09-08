using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.PayeeLocations;

public sealed record PayeeLocation
{
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }

    [JsonPropertyName("payee_id")]
    public required Guid PayeeId { get; init; }

    // TODO: change to double
    [JsonPropertyName("latitude")]
    public required string Latitude { get; init; }

    // TODO: change to double
    [JsonPropertyName("longitude")]
    public required string Longitude { get; init; }

    /// <summary>
    /// Whether the payee location has been deleted. Deleted payee locations will only be included in delta requests
    /// </summary>
    [JsonPropertyName("deleted")]
    public required bool Deleted { get; init; }
}