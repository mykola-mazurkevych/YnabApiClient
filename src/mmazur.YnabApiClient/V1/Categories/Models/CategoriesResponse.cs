using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Categories.Models;

public sealed record CategoriesResponse
{
    [JsonConstructor]
    private CategoriesResponse()
    {
    }

    [JsonPropertyName("category_groups")]
    [JsonRequired]
    public IReadOnlyList<CategoryGroupWithCategories> CategoryGroups { get; init; } = [];

    /// <summary>
    /// The knowledge of the server
    /// </summary>
    [JsonPropertyName("server_knowledge")]
    [JsonRequired]
    public required long ServerKnowledge { get; init; }
}