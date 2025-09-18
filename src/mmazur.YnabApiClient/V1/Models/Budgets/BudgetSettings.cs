using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Budgets;

public sealed record BudgetSettings
{
    [JsonPropertyName("date_format")]
    [JsonRequired]
    public required DateFormat? DateFormat { get; init; }

    [JsonPropertyName("currency_format")]
    [JsonRequired]
    public required CurrencyFormat? CurrencyFormat { get; init; }
}