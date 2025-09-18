#pragma warning disable IDE0044 // Add readonly modifier

using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.PayeeLocations;

public sealed record PayeeLocationsResponse
{
    [JsonConstructor]
    private PayeeLocationsResponse()
    {
    }

    [JsonInclude]
    [JsonPropertyName("payee_locations")]
    [JsonRequired]
    private List<PayeeLocation> _payeeLocations = [];

    [JsonIgnore]
    public IReadOnlyList<PayeeLocation> PayeeLocations => _payeeLocations.AsReadOnly();
}