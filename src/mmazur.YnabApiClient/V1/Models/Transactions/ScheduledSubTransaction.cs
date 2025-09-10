using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Transactions;

public sealed record ScheduledSubTransaction
{
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }

    [JsonPropertyName("scheduled_transaction_id")]
    public required Guid ScheduledTransactionId { get; init; }

    /// <summary>
    /// The scheduled subtransaction amount
    /// </summary>
    [JsonPropertyName("amount")]
    public required decimal Amount { get; init; }

    [JsonPropertyName("memo")]
    public required string? Memo { get; init; }

    [JsonPropertyName("payee_id")]
    public required Guid? PayeeId { get; init; }

    [JsonPropertyName("payee_name")]
    public required string? PayeeName { get; init; }

    [JsonPropertyName("category_id")]
    public required Guid? CategoryId { get; init; }

    [JsonPropertyName("category_name")]
    public required string? CategoryName { get; init; }

    /// <summary>
    /// If a transfer, the account_id which the scheduled subtransaction transfers to
    /// </summary>
    [JsonPropertyName("transfer_account_id")]
    public required Guid? TransferAccountId { get; init; }

    /// <summary>
    /// Whether the scheduled subtransaction has been deleted. Deleted scheduled subtransactions will only be included in delta requests.
    /// </summary>
    [JsonPropertyName("deleted")]
    public required bool Deleted { get; init; }
}