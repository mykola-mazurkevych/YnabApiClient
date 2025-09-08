#pragma warning disable IDE0044 // Add readonly modifier

using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Budgets;

public sealed record BudgetSummaryResponse
{
    [JsonInclude]
    [JsonPropertyName("budgets")]
    private List<BudgetSummary> _budgets = [];

    [JsonPropertyName("default_budget")]
    public BudgetSummary? DefaultBudget { get; init; }

    public IReadOnlyList<BudgetSummary> Budgets => _budgets.AsReadOnly();
}