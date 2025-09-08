#pragma warning disable IDE0044 // Add readonly modifier

using System.Text.Json.Serialization;

using mmazur.YnabApiClient.V1.Models.Categories;

namespace mmazur.YnabApiClient.V1.Models.Months;

public sealed record MonthWithCategories
{
    [JsonInclude]
    [JsonPropertyName("categories")]
    private List<Category> _categories = [];

    [JsonPropertyName("month")]
    public required DateOnly MonthName { get; init; }

    [JsonPropertyName("note")]
    public required string? Note { get; init; }

    [JsonPropertyName("income")]
    public required long Income { get; init; }

    [JsonPropertyName("budgeted")]
    public required long Budgeted { get; init; }

    [JsonPropertyName("activity")]
    public required long Activity { get; init; }

    [JsonPropertyName("to_be_budgeted")]
    public required long ToBeBudgeted { get; init; }

    [JsonPropertyName("age_of_money")]
    public required long AgeOfMoney { get; init; }

    [JsonPropertyName("deleted")]
    public required bool Deleted { get; init; }

    public IReadOnlyList<Category> Categories => _categories.AsReadOnly();
}