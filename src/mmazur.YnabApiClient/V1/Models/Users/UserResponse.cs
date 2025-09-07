using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Users;

public sealed record UserResponse
{
    [JsonPropertyName("user")]
    public User? User { get; init; }
}