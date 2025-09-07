#pragma warning disable IDE0044 // Add readonly modifier

using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Categories;

public sealed record CategoryGroupWithCategoriesResponse
{
    [JsonInclude]
    [JsonPropertyName("category_groups")]
    private List<CategoryGroupWithCategories> _categoryGroups = [];

    public IReadOnlyList<CategoryGroupWithCategories> CategoryGroups => _categoryGroups.AsReadOnly();
}