#pragma warning disable IDE0044 // Add readonly modifier

using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Categories;

public sealed record CategoriesResponse
{
    [JsonInclude]
    [JsonPropertyName("category_groups")]
    private List<CategoryGroupWithCategories> _categoryGroups = [];

    /// <summary>
    /// The knowledge of the server
    /// </summary>
    [JsonPropertyName("server_knowledge")]
    public required long ServerKnowledge { get; init; }

    public IReadOnlyList<CategoryGroupWithCategories> CategoryGroups => _categoryGroups.AsReadOnly();
}