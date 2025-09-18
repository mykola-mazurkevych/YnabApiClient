using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Payees;

public sealed record PayeeResponse
{
    [JsonConstructor]
    private PayeeResponse()
    {
    }

    [JsonPropertyName("payee")]
    [JsonRequired]
    public required Payee Payee { get; init; }
}