#pragma warning disable IDE0044 // Add readonly modifier

using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Categories;

public sealed record CategoryGroupsResponse
{
    [JsonInclude]
    [JsonPropertyName("category_groups")]
    private List<CategoryGroup> _categoryGroups = [];

    public IReadOnlyList<CategoryGroup> CategoryGroups => _categoryGroups.AsReadOnly();

    [JsonPropertyName("server_knowledge")]
    public long ServerKnowledge { get; init; }
}