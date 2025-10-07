using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Users.Models;

public sealed record User
{
    [JsonPropertyName("id")]
    [JsonRequired]
    public required Guid Id { get; init; }
}