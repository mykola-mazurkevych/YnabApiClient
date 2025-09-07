using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Categories;

internal sealed record UpdateCategoryRequest
{
    [JsonPropertyName("category")]
    public required UpdateCategory Category { get; init; }
}