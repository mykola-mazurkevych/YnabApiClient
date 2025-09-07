#pragma warning disable IDE0044 // Add readonly modifier

using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Budgets;

public sealed record BudgetWithAccountsResponse
{
    [JsonInclude]
    [JsonPropertyName("budgets")]
    private List<BudgetWithAccounts> _budgets = [];

    public IReadOnlyList<BudgetWithAccounts> Budgets => _budgets.AsReadOnly();
}