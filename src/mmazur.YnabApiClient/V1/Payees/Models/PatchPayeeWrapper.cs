using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Payees.Models;

internal sealed record PatchPayeeWrapper
{
    [JsonPropertyName("payee")]
    public required SavePayee Payee { get; init; }
}