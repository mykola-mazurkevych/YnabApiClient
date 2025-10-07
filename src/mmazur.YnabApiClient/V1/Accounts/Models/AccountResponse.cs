using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Accounts.Models;

public sealed record AccountResponse
{
    [JsonConstructor]
    private AccountResponse()
    {
    }

    [JsonPropertyName("account")]
    [JsonRequired]
    public required Account Account { get; init; }
}