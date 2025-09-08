#pragma warning disable IDE0044 // Add readonly modifier

using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Months;

public sealed record MonthsResponse
{
    [JsonInclude]
    [JsonPropertyName("months")]
    private List<Month> _months = [];

    public IReadOnlyList<Month> Months => _months.AsReadOnly();
}