using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Users;

public sealed record User
{
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }
}