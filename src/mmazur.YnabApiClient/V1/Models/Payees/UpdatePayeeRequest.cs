using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Payees;

internal sealed record UpdatePayeeRequest
{
    [JsonPropertyName("payee")]
    public required UpdatePayee Payee { get; init; }
}