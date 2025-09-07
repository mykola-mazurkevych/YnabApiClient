using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Budgets;

public sealed record BudgetSettingsResponse
{
    [JsonPropertyName("settings")]
    public BudgetSettings? Settings { get; init; }
}