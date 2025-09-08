using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Months;

public sealed record MonthWithCategoriesResponse
{
    [JsonPropertyName("month")]
    public MonthWithCategories? Month { get; init; }
}