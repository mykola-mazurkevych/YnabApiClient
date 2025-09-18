#pragma warning disable IDE0044 // Add readonly modifier

using System.Text.Json.Serialization;

using mmazur.YnabApiClient.V1.Models.Categories;

namespace mmazur.YnabApiClient.V1.Models.Months;

public sealed record MonthDetail
{
    /// <summary>
    /// The budget month categories. Amounts (budgeted, activity, balance, etc.) are specific to the {month} parameter specified
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("categories")]
    [JsonRequired]
    private List<Category> _categories = [];

    [JsonPropertyName("month")]
    [JsonRequired]
    public required DateOnly Month { get; init; }

    [JsonPropertyName("note")]
    public string? Note { get; init; }

    /// <summary>
    /// The total amount of transactions categorized to 'Inflow: Ready to Assign' in the month
    /// </summary>
    [JsonPropertyName("income")]
    [JsonRequired]
    public required decimal Income { get; init; }

    /// <summary>
    /// The total amount budgeted in the month
    /// </summary>
    [JsonPropertyName("budgeted")]
    [JsonRequired]
    public required decimal Budgeted { get; init; }

    /// <summary>
    /// The total amount of transactions in the month, excluding those categorized to 'Inflow: Ready to Assign'
    /// </summary>
    [JsonPropertyName("activity")]
    [JsonRequired]
    public required decimal Activity { get; init; }

    /// <summary>
    /// The available amount for 'Ready to Assign'
    /// </summary>
    [JsonPropertyName("to_be_budgeted")]
    [JsonRequired]
    public required decimal ToBeBudgeted { get; init; }

    /// <summary>
    /// The Age of Money as of the month
    /// </summary>
    [JsonPropertyName("age_of_money")]
    public int? AgeOfMoney { get; init; }

    /// <summary>
    /// Whether the month has been deleted. Deleted months will only be included in delta requests
    /// </summary>
    [JsonPropertyName("deleted")]
    [JsonRequired]
    public required bool Deleted { get; init; }

    [JsonIgnore]
    public IReadOnlyList<Category> Categories => _categories.AsReadOnly();
}