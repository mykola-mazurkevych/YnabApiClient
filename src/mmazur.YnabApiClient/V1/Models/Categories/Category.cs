#pragma warning disable CA1041 // Provide ObsoleteAttribute message

using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Categories;

public sealed record Category
{
    [JsonPropertyName("id")]
    [JsonRequired]
    public required Guid Id { get; init; }

    [JsonPropertyName("category_group_id")]
    [JsonRequired]
    public required Guid CategoryGroupId { get; init; }

    [JsonPropertyName("category_group_name")]
    public string? CategoryGroupName { get; init; }

    [JsonPropertyName("name")]
    [JsonRequired]
    public required string Name { get; init; }

    /// <summary>
    /// Whether the category is hidden
    /// </summary>
    [JsonPropertyName("hidden")]
    [JsonRequired]
    public required bool Hidden { get; init; }

    /// <summary>
    /// DEPRECATED: No longer used. Value will always be null
    /// </summary>
    [JsonPropertyName("original_category_group_id")]
    [Obsolete("No longer used. Value will always be null")]
    public Guid? OriginalCategoryGroupId { get; init; }

    [JsonPropertyName("note")]
    public string? Note { get; init; }

    /// <summary>
    /// Budgeted amount
    /// </summary>
    [JsonPropertyName("budgeted")]
    [JsonRequired]
    public required decimal Budgeted { get; init; }

    /// <summary>
    /// Activity amount
    /// </summary>
    [JsonPropertyName("activity")]
    [JsonRequired]
    public required decimal Activity { get; init; }

    /// <summary>
    /// Balance
    /// </summary>
    [JsonPropertyName("balance")]
    [JsonRequired]
    public required decimal Balance { get; init; }

    /// <summary>
    /// The type of goal, if the category has a goal
    /// </summary>
    [JsonPropertyName("goal_type")]
    public GoalType? GoalType { get; init; }

    /// <summary>
    /// Indicates the monthly rollover behavior for "NEED"-type goals.
    /// When "true", the goal will always ask for the target amount in the new month ("Set Aside").
    /// When "false", previous month category funding is used ("Refill"). For other goal types, this field will be null.
    /// </summary>
    [JsonPropertyName("goal_needs_whole_amount")]
    public bool? GoalNeedsWholeAmount { get; init; }

    /// <summary>
    /// A day offset modifier for the goal's due date.
    /// When goal_cadence is 2 (Weekly), this value specifies which day of the week the goal is due (0 = Sunday, 6 = Saturday).
    /// Otherwise, this value specifies which day of the month the goal is due (1 = 1st, 31 = 31st, null = Last day of Month).
    /// </summary>
    [JsonPropertyName("goal_day")]
    public int? GoalDay { get; init; }

    /// <summary>
    /// The goal cadence.
    /// Value in range 0-14.
    /// There are two subsets of these values which behave differently.
    /// For values 0, 1, 2, and 13, the goal's due date repeats every goal_cadence * goal_cadence_frequency, where 0 = None, 1 = Monthly, 2 = Weekly, and 13 = Yearly. For example, goal_cadence 1 with goal_cadence_frequency 2 means the goal is due every other month.
    /// For values 3-12 and 14, goal_cadence_frequency is ignored and the goal's due date repeats every goal_cadence, where 3 = Every 2 Months, 4 = Every 3 Months, ..., 12 = Every 11 Months, and 14 = Every 2 Years.
    /// </summary>
    [JsonPropertyName("goal_cadence")]
    public int? GoalCadence { get; init; }

    /// <summary>
    /// The goal cadence frequency.
    /// When goal_cadence is 0, 1, 2, or 13, a goal's due date repeats every goal_cadence * goal_cadence_frequency.
    /// For example, goal_cadence 1 with goal_cadence_frequency 2 means the goal is due every other month.
    /// When goal_cadence is 3-12 or 14, goal_cadence_frequency is ignored.
    /// </summary>
    [JsonPropertyName("goal_cadence_frequency")]
    public int? GoalCadenceFrequency { get; init; }

    /// <summary>
    /// The month a goal was created
    /// </summary>
    [JsonPropertyName("goal_creation_month")]
    public DateOnly? GoalCreationMonth { get; init; }

    /// <summary>
    /// The goal target amount
    /// </summary>
    [JsonPropertyName("goal_target")]
    public decimal? GoalTarget { get; init; }

    /// <summary>
    /// The original target month for the goal to be completed. Only some goal types specify this date.
    /// </summary>
    [JsonPropertyName("goal_target_month")]
    public DateOnly? GoalTargetMonth { get; init; }

    /// <summary>
    /// The percentage completion of the goal
    /// </summary>
    [JsonPropertyName("goal_percentage_complete")]
    public int? GoalPercentageComplete { get; init; }

    /// <summary>
    /// The number of months, including the current month, left in the current goal period.
    /// </summary>
    [JsonPropertyName("goal_months_to_budget")]
    public int? GoalMonthsToBudget { get; init; }

    /// <summary>
    /// The amount of funding still needed in the current month to stay on track towards completing the goal within the current goal period.
    /// This amount will generally correspond to the 'Underfunded' amount in the web and mobile clients except when viewing a category with a Needed for Spending Goal in a future month.
    /// The web and mobile clients will ignore any funding from a prior goal period when viewing category with a Needed for Spending Goal in a future month.
    /// </summary>
    [JsonPropertyName("goal_under_funded")]
    public decimal? GoalUnderFunded { get; init; }

    /// <summary>
    /// The total amount funded towards the goal within the current goal period
    /// </summary>
    [JsonPropertyName("goal_overall_funded")]
    public decimal? GoalOverallFunded { get; init; }

    /// <summary>
    /// The amount of funding still needed to complete the goal within the current goal period
    /// </summary>
    [JsonPropertyName("goal_overall_left")]
    public decimal? GoalOverallLeft { get; init; }

    /// <summary>
    /// The date/time the goal was snoozed. If the goal is not snoozed, this will be null
    /// </summary>
    [JsonPropertyName("goal_snoozed_at")]
    public DateTimeOffset? GoalSnoozedAt { get; init; }

    /// <summary>
    /// Whether the category has been deleted. Deleted categories will only be included in delta requests
    /// </summary>
    [JsonPropertyName("deleted")]
    [JsonRequired]
    public required bool Deleted { get; init; }
}