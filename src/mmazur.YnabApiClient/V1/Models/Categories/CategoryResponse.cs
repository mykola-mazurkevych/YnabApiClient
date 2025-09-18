using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Categories;

public sealed class CategoryResponse
{
    [JsonPropertyName("category")]
    public required Category Category { get; init; }
}