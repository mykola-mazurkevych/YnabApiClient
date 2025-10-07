using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Accounts.Models;

public sealed record SaveAccount
{
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("type")]
    public required AccountType Type { get; init; }

    [JsonPropertyName("balance")]
    public required decimal Balance { get; init; }
}