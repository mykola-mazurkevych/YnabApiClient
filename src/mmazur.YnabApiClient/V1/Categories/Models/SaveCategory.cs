using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Categories.Models;

public sealed record SaveCategory
{
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("note")]
    public string? Note { get; init; }

    [JsonPropertyName("category_group_id")]
    public Guid CategoryGroupId { get; init; }

    [JsonPropertyName("goal_target")]
    public decimal? GoalTarget { get; init; }
}