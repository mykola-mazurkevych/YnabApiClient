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
    public required Guid Id { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("type")]
    public required AccountType Type { get; init; }

    [JsonPropertyName("on_budget")]
    public required bool OnBudget { get; init; }

    [JsonPropertyName("closed")]
    public required bool Closed { get; init; }

    [JsonPropertyName("note")]
    public required string? Note { get; init; }

    [JsonPropertyName("balance")]
    public required decimal Balance { get; init; }

    [JsonPropertyName("cleared_balance")]
    public required decimal ClearedBalance { get; init; }

    [JsonPropertyName("uncleared_balance")]
    public required decimal UnclearedBalance { get; init; }

    [JsonPropertyName("transfer_payee_id")]
    public required Guid? TransferPayeeId { get; init; }

    [JsonPropertyName("direct_import_linked")]
    public required bool DirectImportLinked { get; init; }

    [JsonPropertyName("direct_import_in_error")]
    public required bool DirectImportInError { get; init; }

    [JsonPropertyName("last_reconciled_at")]
    public required DateTimeOffset? LastReconciledAt { get; init; }

    [JsonPropertyName("debt_original_balance")]
    public required decimal? DebtOriginalBalance { get; init; }

    public IReadOnlyDictionary<string, decimal> DebtInterestRates => _debtInterestRates.AsReadOnly();

    public IReadOnlyDictionary<string, decimal> DebtMinimumPayments => _debtMinimumPayments.AsReadOnly();

    public IReadOnlyDictionary<string, decimal> DebtEscrowAmounts => _debtEscrowAmounts.AsReadOnly();

    [JsonPropertyName("deleted")]
    public required bool Deleted { get; init; }
}