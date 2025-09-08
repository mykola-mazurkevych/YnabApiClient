using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Accounts;

internal sealed record PostAccountWrapper
{
    [JsonPropertyName("account")]
    public required SaveAccount Account { get; init; }
}