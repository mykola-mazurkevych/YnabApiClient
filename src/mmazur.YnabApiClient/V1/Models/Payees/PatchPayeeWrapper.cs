using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Payees;

internal sealed record PatchPayeeWrapper
{
    [JsonPropertyName("payee")]
    public required SavePayee Payee { get; init; }
}