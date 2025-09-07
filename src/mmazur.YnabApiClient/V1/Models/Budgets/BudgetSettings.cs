using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Budgets;

public sealed record BudgetSettings
{
    [JsonPropertyName("date_format")]
    public required DateFormat DateFormat { get; init; }

    [JsonPropertyName("currency_format")]
    public required CurrencyFormat CurrencyFormat { get; init; }
}