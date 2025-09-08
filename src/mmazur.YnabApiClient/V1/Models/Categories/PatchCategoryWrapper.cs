using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Categories;

internal sealed record PatchCategoryWrapper
{
    [JsonPropertyName("category")]
    public required SaveCategory Category { get; init; }
}