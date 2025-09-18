using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Accounts;

public sealed record AccountResponse
{
    [JsonPropertyName("account")]
    public required Account Account { get; init; }
}