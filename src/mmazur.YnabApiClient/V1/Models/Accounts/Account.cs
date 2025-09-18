#pragma warning disable CA1041 // Provide ObsoleteAttribute message
#pragma warning disable IDE0044 // Add readonly modifier

using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Accounts;

public sealed record Account
{
    [JsonInclude]
    [JsonPropertyName("debt_interest_rates")]
    private Dictionary<string, decimal> _debtInterestRates = [];

    [JsonInclude]
    [JsonPropertyName("debt_minimum_payments")]
    private Dictionary<string, decimal> _debtMinimumPayments = [];

    [JsonInclude]
    [JsonPropertyName("debt_escrow_amounts")]
    private Dictionary<string, decimal> _debtEscrowAmounts = [];

    [JsonPropertyName("id")]
    [JsonRequired]
    public required Guid Id { get; init; }

    [JsonPropertyName("name")]
    [JsonRequired]
    public required string Name { get; init; }

    [JsonPropertyName("type")]
    [JsonRequired]
    public required AccountType Type { get; init; }

    /// <summary>
    /// Whether this account is on budget or not
    /// </summary>
    [JsonPropertyName("on_budget")]
    [JsonRequired]
    public required bool OnBudget { get; init; }

    /// <summary>
    /// Whether this account is closed or not
    /// </summary>
    [JsonPropertyName("closed")]
    [JsonRequired]
    public required bool Closed { get; init; }

    [JsonPropertyName("note")]
    public string? Note { get; init; }

    /// <summary>
    /// The current balance of the account
    /// </summary>
    [JsonPropertyName("balance")]
    [JsonRequired]
    public required decimal Balance { get; init; }

    /// <summary>
    /// The current cleared balance of the account
    /// </summary>
    [JsonPropertyName("cleared_balance")]
    [JsonRequired]
    public required decimal ClearedBalance { get; init; }

    /// <summary>
    /// The current uncleared balance of the account
    /// </summary>
    [JsonPropertyName("uncleared_balance")]
    [JsonRequired]
    public required decimal UnclearedBalance { get; init; }

    /// <summary>
    /// The payee id which should be used when transferring to this account
    /// </summary>
    [JsonPropertyName("transfer_payee_id")]
    [JsonRequired]
    public required Guid TransferPayeeId { get; init; }

    /// <summary>
    /// Whether the account is linked to a financial institution for automatic transaction import
    /// </summary>
    [JsonPropertyName("direct_import_linked")]
    public bool DirectImportLinked { get; init; }

    /// <summary>
    /// If an account linked to a financial institution (direct_import_linked=true) and the linked connection is not in a healthy state, this will be true
    /// </summary>
    [JsonPropertyName("direct_import_in_error")]
    public bool DirectImportInError { get; init; }

    /// <summary>
    /// A date/time specifying when the account was last reconciled
    /// </summary>
    [JsonPropertyName("last_reconciled_at")]
    public DateTimeOffset? LastReconciledAt { get; init; }

    /// <summary>
    /// This field is deprecated and will always be null
    /// </summary>
    [Obsolete("This field is deprecated and will always be null")]
    [JsonPropertyName("debt_original_balance")]
    public decimal? DebtOriginalBalance { get; init; }

    /// <summary>
    /// Whether the account has been deleted. Deleted accounts will only be included in delta requests
    /// </summary>
    [JsonPropertyName("deleted")]
    [JsonRequired]
    public required bool Deleted { get; init; }

    [JsonIgnore]
    public IReadOnlyDictionary<string, decimal> DebtInterestRates => _debtInterestRates.AsReadOnly();

    [JsonIgnore]
    public IReadOnlyDictionary<string, decimal> DebtMinimumPayments => _debtMinimumPayments.AsReadOnly();

    [JsonIgnore]
    public IReadOnlyDictionary<string, decimal> DebtEscrowAmounts => _debtEscrowAmounts.AsReadOnly();
}