using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Budgets;

public sealed record DateFormat
{
    [JsonPropertyName("format")]
    public required string Format { get; init; }
}