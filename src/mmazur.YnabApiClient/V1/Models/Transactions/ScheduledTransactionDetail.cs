#pragma warning disable IDE0044 // Add readonly modifier

using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Transactions;

public sealed record ScheduledTransactionDetail
{
    /// <summary>
    /// If a split scheduled transaction, the subtransactions
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("subtransactions")]
    private List<ScheduledSubTransaction> _scheduledSubTransactions = [];

    [JsonPropertyName("id")]
    public required Guid Id { get; init; }

    /// <summary>
    /// The first date for which the Scheduled Transaction was scheduled
    /// </summary>
    [JsonPropertyName("date_first")]
    public required DateOnly DateFirst { get; init; }

    /// <summary>
    /// The next date for which the Scheduled Transaction is scheduled
    /// </summary>
    [JsonPropertyName("date_next")]
    public required DateOnly DateNext { get; init; }

    [JsonPropertyName("frequency")]
    public required ScheduledTransactionFrequency Frequency { get; init; }

    /// <summary>
    /// The scheduled transaction amount
    /// </summary>
    [JsonPropertyName("amount")]
    public required decimal Amount { get; init; }

    [JsonPropertyName("memo")]
    public required string? Memo { get; init; }

    /// <summary>
    /// The transaction flag
    /// </summary>
    [JsonPropertyName("flag_color")]
    public required TransactionFlagColor? FlagColor { get; init; }

    /// <summary>
    /// The customized name of a transaction flag
    /// </summary>
    [JsonPropertyName("flag_name")]
    public required string? FlagName { get; init; }

    [JsonPropertyName("account_id")]
    public required Guid AccountId { get; init; }

    [JsonPropertyName("account_name")]
    public required string AccountName { get; init; }

    [JsonPropertyName("payee_id")]
    public required Guid? PayeeId { get; init; }

    [JsonPropertyName("payee_name")]
    public required string? PayeeName { get; init; }

    [JsonPropertyName("category_id")]
    public required Guid? CategoryId { get; init; }

    /// <summary>
    /// The name of the category. If a split scheduled transaction, this will be 'Split'.
    /// </summary>
    [JsonPropertyName("category_name")]
    public required string? CategoryName { get; init; }

    /// <summary>
    /// If a transfer, the account_id which the scheduled transaction transfers to
    /// </summary>
    [JsonPropertyName("transfer_account_id")]
    public required Guid? TransferAccountId { get; init; }

    /// <summary>
    /// Whether the scheduled transaction has been deleted. Deleted scheduled transactions will only be included in delta requests
    /// </summary>
    [JsonPropertyName("deleted")]
    public required bool Deleted { get; init; }

    public IReadOnlyList<ScheduledSubTransaction> ScheduledSubTransactions => _scheduledSubTransactions.AsReadOnly();
}