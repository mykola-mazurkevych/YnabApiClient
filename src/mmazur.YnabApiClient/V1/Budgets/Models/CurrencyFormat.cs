using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Budgets.Models;

/// <summary>
/// The currency format setting for the budget. In some cases the format will not be available and will be specified as null.
/// </summary>
public sealed record CurrencyFormat
{
    [JsonPropertyName("iso_code")]
    [JsonRequired]
    public required string IsoCode { get; init; }

    [JsonPropertyName("example_format")]
    [JsonRequired]
    public required string ExampleFormat { get; init; }

    [JsonPropertyName("decimal_digits")]
    [JsonRequired]
    public required int DecimalDigits { get; init; }

    [JsonPropertyName("decimal_separator")]
    [JsonRequired]
    public required string DecimalSeparator { get; init; }

    [JsonPropertyName("symbol_first")]
    [JsonRequired]
    public required bool SymbolFirst { get; init; }

    [JsonPropertyName("group_separator")]
    [JsonRequired]
    public required string GroupSeparator { get; init; }

    [JsonPropertyName("currency_symbol")]
    [JsonRequired]
    public required string CurrencySymbol { get; init; }

    [JsonPropertyName("display_symbol")]
    [JsonRequired]
    public required bool DisplaySymbol { get; init; }
}