using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Months.Models;

public sealed record MonthSummariesResponse
{
    [JsonConstructor]
    private MonthSummariesResponse()
    {
    }

    [JsonPropertyName("months")]
    [JsonRequired]
    public IReadOnlyList<MonthSummary> Months { get; init; } = [];

    /// <summary>
    /// The knowledge of the server
    /// </summary>
    [JsonPropertyName("server_knowledge")]
    [JsonRequired]
    public required long ServerKnowledge { get; init; }
}