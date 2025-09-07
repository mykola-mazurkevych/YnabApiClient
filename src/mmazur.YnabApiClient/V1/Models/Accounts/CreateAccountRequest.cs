using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Accounts;

internal sealed record CreateAccountRequest
{
    [JsonPropertyName("account")]
    public required CreateAccount CreateAccount { get; init; }
}