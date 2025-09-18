using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Months;

public sealed record MonthDetailResponse
{
    [JsonConstructor]
    private MonthDetailResponse()
    {
    }

    [JsonPropertyName("month")]
    [JsonRequired]
    public required MonthDetail Month { get; init; }
}