using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Months;

public sealed record Month
{
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
}