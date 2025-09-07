using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Accounts;

public sealed record CreateAccount
{
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("type")]
    public required AccountType Type { get; init; }

    [JsonPropertyName("balance")]
    public decimal Balance { get; init; }
}