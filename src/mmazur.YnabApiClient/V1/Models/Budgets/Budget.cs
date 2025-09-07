using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Budgets;

public sealed record Budget
{
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("last_modified_on")]
    public required DateTimeOffset LastModifiedOn { get; init; }

    [JsonPropertyName("first_month")]
    public required DateOnly FirstMonth { get; init; }

    [JsonPropertyName("last_month")]
    public required DateOnly LastMonth { get; init; }

    [JsonPropertyName("date_format")]
    public required DateFormat DateFormat { get; init; }

    [JsonPropertyName("currency_format")]
    public required CurrencyFormat CurrencyFormat { get; init; }
}