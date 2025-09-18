#pragma warning disable IDE0044 // Add readonly modifier

using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Budgets;

public sealed record BudgetDetailResponse
{
    [JsonConstructor]
    private BudgetDetailResponse()
    {
    }

    [JsonInclude]
    [JsonPropertyName("budgets")]
    [JsonRequired]
    private List<BudgetDetail> _budgets = [];

    /// <summary>
    /// The knowledge of the server
    /// </summary>
    [JsonPropertyName("server_knowledge")]
    [JsonRequired]
    public required long ServerKnowledge { get; init; }

    [JsonIgnore]
    public IReadOnlyList<BudgetDetail> Budgets => _budgets.AsReadOnly();
}