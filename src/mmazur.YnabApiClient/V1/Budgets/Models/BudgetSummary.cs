#pragma warning disable IDE0044 // Add readonly modifier

using System.Text.Json.Serialization;

using mmazur.YnabApiClient.V1.Accounts.Models;

namespace mmazur.YnabApiClient.V1.Budgets.Models;

public sealed record BudgetSummary
{
    /// <summary>
    /// The budget accounts (only included if include_accounts=true specified as query parameter)
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("accounts")]
    private List<Account> _accounts = [];

    [JsonPropertyName("id")]
    [JsonRequired]
    public required Guid Id { get; init; }

    [JsonPropertyName("name")]
    [JsonRequired]
    public required string Name { get; init; }

    /// <summary>
    /// The last time any changes were made to the budget from either a web or mobile client
    /// </summary>
    [JsonPropertyName("last_modified_on")]
    public DateTimeOffset? LastModifiedOn { get; init; }

    /// <summary>
    /// The earliest budget month
    /// </summary>
    [JsonPropertyName("first_month")]
    public DateOnly? FirstMonth { get; init; }

    /// <summary>
    /// The latest budget month
    /// </summary>
    [JsonPropertyName("last_month")]
    public DateOnly? LastMonth { get; init; }

    [JsonPropertyName("date_format")]
    public DateFormat? DateFormat { get; init; }

    [JsonPropertyName("currency_format")]
    public CurrencyFormat? CurrencyFormat { get; init; }

    [JsonIgnore]
    public IReadOnlyList<Account> Accounts => _accounts.AsReadOnly();
}