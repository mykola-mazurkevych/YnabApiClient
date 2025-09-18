using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Budgets;

public sealed record BudgetSettingsResponse
{
    [JsonConstructor]
    private BudgetSettingsResponse()
    {
    }

    [JsonPropertyName("settings")]
    [JsonRequired]
    public required BudgetSettings Settings { get; init; }
}