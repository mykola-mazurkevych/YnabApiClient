#pragma warning disable IDE0044 // Add readonly modifier

using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Budgets.Models;

public sealed record BudgetSummaryResponse
{
    [JsonConstructor]
    private BudgetSummaryResponse()
    {
    }

    [JsonInclude]
    [JsonPropertyName("budgets")]
    [JsonRequired]
    private List<BudgetSummary> _budgets = [];

    [JsonPropertyName("default_budget")]
    public BudgetSummary? DefaultBudget { get; init; }

    [JsonIgnore]
    public IReadOnlyList<BudgetSummary> Budgets => _budgets.AsReadOnly();
}