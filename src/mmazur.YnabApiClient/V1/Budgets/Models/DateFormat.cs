using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Budgets.Models;

/// <summary>
/// The date format setting for the budget. In some cases the format will not be available and will be specified as null.
/// </summary>
public sealed record DateFormat
{
    [JsonPropertyName("format")]
    [JsonRequired]
    public required string Format { get; init; }
}