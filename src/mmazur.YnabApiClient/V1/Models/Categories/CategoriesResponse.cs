#pragma warning disable IDE0044 // Add readonly modifier

using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Categories;

public sealed record CategoriesResponse
{
    [JsonConstructor]
    private CategoriesResponse()
    {
    }

    [JsonInclude]
    [JsonPropertyName("category_groups")]
    [JsonRequired]
    private List<CategoryGroupWithCategories> _categoryGroups = [];

    /// <summary>
    /// The knowledge of the server
    /// </summary>
    [JsonPropertyName("server_knowledge")]
    [JsonRequired]
    public required long ServerKnowledge { get; init; }

    [JsonIgnore]
    public IReadOnlyList<CategoryGroupWithCategories> CategoryGroups => _categoryGroups.AsReadOnly();
}