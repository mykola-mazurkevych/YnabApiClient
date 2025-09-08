#pragma warning disable IDE0044 // Add readonly modifier

using System.Text.Json.Serialization;

using mmazur.YnabApiClient.V1.Models.Accounts;

namespace mmazur.YnabApiClient.V1.Models.Budgets;

public sealed record BudgetSummary
{
    [JsonInclude]
    [JsonPropertyName("accounts")]
    private List<Account> _accounts = [];

    [JsonPropertyName("id")]
    public required Guid Id { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>
    /// The last time any changes were made to the budget from either a web or mobile client
    /// </summary>
    [JsonPropertyName("last_modified_on")]
    public required DateTimeOffset? LastModifiedOn { get; init; }

    /// <summary>
    /// The earliest budget month
    /// </summary>
    [JsonPropertyName("first_month")]
    public required DateOnly? FirstMonth { get; init; }

    /// <summary>
    /// The latest budget month
    /// </summary>
    [JsonPropertyName("last_month")]
    public required DateOnly? LastMonth { get; init; }

    [JsonPropertyName("date_format")]
    public required DateFormat? DateFormat { get; init; }

    [JsonPropertyName("currency_format")]
    public required CurrencyFormat? CurrencyFormat { get; init; }

    /// <summary>
    /// The budget accounts (only included if include_accounts=true specified as query parameter)
    /// </summary>
    public IReadOnlyList<Account> Accounts => _accounts.AsReadOnly();
}