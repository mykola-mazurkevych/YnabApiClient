#pragma warning disable IDE0044 // Add readonly modifier

using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Budgets;

public sealed record BudgetsResponse
{
    [JsonInclude]
    [JsonPropertyName("budgets")]
    private List<Budget> _budgets = [];

    public IReadOnlyList<Budget> Budgets => _budgets.AsReadOnly();

    [JsonPropertyName("default_budget")]
    public Budget? DefaultBudget { get; init; }
}