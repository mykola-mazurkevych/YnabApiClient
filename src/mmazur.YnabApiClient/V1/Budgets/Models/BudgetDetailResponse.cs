#pragma warning disable IDE0044 // Add readonly modifier

using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Budgets.Models;

public sealed record BudgetDetailResponse
{
    [JsonConstructor]
    private BudgetDetailResponse()
    {
    }

    [JsonPropertyName("budget")]
    [JsonRequired]
    public required BudgetDetail Budget { get; init; }

    /// <summary>
    /// The knowledge of the server
    /// </summary>
    [JsonPropertyName("server_knowledge")]
    [JsonRequired]
    public required long ServerKnowledge { get; init; }
}