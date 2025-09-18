#pragma warning disable IDE0044 // Add readonly modifier

using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Months;

public sealed record MonthSummariesResponse
{
    [JsonInclude]
    [JsonPropertyName("months")]
    private List<MonthSummary> _months = [];

    /// <summary>
    /// The knowledge of the server
    /// </summary>
    [JsonPropertyName("server_knowledge")]
    public required long ServerKnowledge { get; init; }

    public IReadOnlyList<MonthSummary> Months => _months.AsReadOnly();
}