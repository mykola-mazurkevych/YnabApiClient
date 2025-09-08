using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Categories;

public sealed record SaveCategory
{
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("note")]
    public required string? Note { get; init; }

    [JsonPropertyName("category_group_id")]
    public required Guid CategoryGroupId { get; init; }

    [JsonPropertyName("goal_target")]
    public required decimal GoalTarget { get; init; }
}