using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Users;

public sealed record UserResponse
{
    [JsonConstructor]
    private UserResponse()
    {
    }

    [JsonPropertyName("user")]
    [JsonRequired]
    public required User User { get; init; }
}