#pragma warning disable IDE0044 // Add readonly modifier

using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Budgets;

public sealed record BudgetDetailResponse
{
    [JsonInclude]
    [JsonPropertyName("budgets")]
    private List<BudgetDetail> _budgets = [];

    /// <summary>
    /// The knowledge of the server
    /// </summary>
    [JsonPropertyName("server_knowledge")]
    public long ServerKnowledge { get; init; }

    public IReadOnlyList<BudgetDetail> Budgets => _budgets.AsReadOnly();
}