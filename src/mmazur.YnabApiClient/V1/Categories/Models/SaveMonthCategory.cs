using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Categories.Models;

public sealed record SaveMonthCategory
{
    [JsonPropertyName("budgeted")]
    public decimal Budgeted { get; init; }
}