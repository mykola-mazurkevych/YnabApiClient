using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Budgets.Models;

public sealed record BudgetSummaryResponse
{
    [JsonConstructor]
    private BudgetSummaryResponse()
    {
    }

    [JsonPropertyName("budgets")]
    [JsonRequired]
    public IReadOnlyList<BudgetSummary> Budgets { get; init; } = [];

    [JsonPropertyName("default_budget")]
    public BudgetSummary? DefaultBudget { get; init; }

}