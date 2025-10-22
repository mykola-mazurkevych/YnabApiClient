using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Categories.Models;

internal sealed record PatchMonthCategoryWrapper
{
    [JsonPropertyName("category")]
    public required SaveMonthCategory Category { get; init; }
}