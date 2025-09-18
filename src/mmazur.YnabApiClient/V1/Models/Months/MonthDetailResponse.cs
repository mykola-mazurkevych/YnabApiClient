using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Months;

public sealed record MonthDetailResponse
{
    [JsonPropertyName("month")]
    public required MonthDetail Month { get; init; }
}