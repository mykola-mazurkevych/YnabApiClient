using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Categories;

public sealed record Category
{
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }

    [JsonPropertyName("category_group_id")]
    public required Guid CategoryGroupId { get; init; }

    [JsonPropertyName("category_group_name")]
    public required string CategoryGroupName { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("hidden")]
    public required bool Hidden { get; init; }

    [JsonPropertyName("original_category_group_id")]
    public required Guid OriginalCategoryGroupId { get; init; }

    [JsonPropertyName("note")]
    public required string? Note { get; init; }

    [JsonPropertyName("budgeted")]
    public required long Budgeted { get; init; }

    [JsonPropertyName("activity")]
    public required long Activity { get; init; }

    [JsonPropertyName("balance")]
    public required long Balance { get; init; }

    [JsonPropertyName("goal_type")]
    public required string? GoalType { get; init; }

    [JsonPropertyName("goal_needs_whole_amount")]
    public required bool? GoalNeedsWholeAmount { get; init; }

    [JsonPropertyName("goal_day")]
    public required int? GoalDay { get; init; }

    [JsonPropertyName("goal_cadence")]
    public required int? GoalCadence { get; init; }

    [JsonPropertyName("goal_cadence_frequency")]
    public required int? GoalCadenceFrequency { get; init; }

    [JsonPropertyName("goal_creation_month")]
    public required string? GoalCreationMonth { get; init; }

    [JsonPropertyName("goal_target")]
    public required long? GoalTarget { get; init; }

    [JsonPropertyName("goal_target_month")]
    public required string? GoalTargetMonth { get; init; }

    [JsonPropertyName("goal_percentage_complete")]
    public required int? GoalPercentageComplete { get; init; }

    [JsonPropertyName("goal_months_to_budget")]
    public required int? GoalMonthsToBudget { get; init; }

    [JsonPropertyName("goal_under_funded")]
    public required long? GoalUnderFunded { get; init; }

    [JsonPropertyName("goal_overall_funded")]
    public required long? GoalOverallFunded { get; init; }

    [JsonPropertyName("goal_overall_left")]
    public required long? GoalOverallLeft { get; init; }

    [JsonPropertyName("goal_snoozed_at")]
    public required DateTimeOffset? GoalSnoozedAt { get; init; }

    [JsonPropertyName("deleted")]
    public required bool Deleted { get; init; }
}