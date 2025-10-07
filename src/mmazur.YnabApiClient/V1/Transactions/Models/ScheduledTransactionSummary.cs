using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Transactions.Models;

public sealed record ScheduledTransactionSummary
{
    [JsonPropertyName("id")]
    [JsonRequired]
    public required Guid Id { get; init; }

    /// <summary>
    /// The first date for which the Scheduled Transaction was scheduled
    /// </summary>
    [JsonPropertyName("date_first")]
    [JsonRequired]
    public required DateOnly DateFirst { get; init; }

    /// <summary>
    /// The next date for which the Scheduled Transaction is scheduled
    /// </summary>
    [JsonPropertyName("date_next")]
    [JsonRequired]
    public required DateOnly DateNext { get; init; }

    [JsonPropertyName("frequency")]
    [JsonRequired]
    public required ScheduledTransactionFrequency Frequency { get; init; }

    /// <summary>
    /// The scheduled transaction amount
    /// </summary>
    [JsonPropertyName("amount")]
    [JsonRequired]
    public required decimal Amount { get; init; }

    [JsonPropertyName("memo")]
    public string? Memo { get; init; }

    /// <summary>
    /// The transaction flag
    /// </summary>
    [JsonPropertyName("flag_color")]
    public TransactionFlagColor? FlagColor { get; init; }

    /// <summary>
    /// The customized name of a transaction flag
    /// </summary>
    [JsonPropertyName("flag_name")]
    public string? FlagName { get; init; }

    [JsonPropertyName("account_id")]
    [JsonRequired]
    public required Guid? AccountId { get; init; }

    [JsonPropertyName("payee_id")]
    public Guid? PayeeId { get; init; }

    [JsonPropertyName("category_id")]
    public Guid? CategoryId { get; init; }

    /// <summary>
    /// If a transfer, the account_id which the scheduled transaction transfers to
    /// </summary>
    [JsonPropertyName("transfer_account_id")]
    public Guid? TransferAccountId { get; init; }

    /// <summary>
    /// Whether the scheduled transaction has been deleted. Deleted scheduled transactions will only be included in delta requests.
    /// </summary>
    [JsonPropertyName("deleted")]
    [JsonRequired]
    public required bool Deleted { get; init; }
}