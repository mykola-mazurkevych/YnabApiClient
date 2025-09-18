using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Payees;

public sealed record PayeeResponse
{
    [JsonPropertyName("payee")]
    public required Payee Payee { get; init; }
}