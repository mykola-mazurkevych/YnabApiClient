using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Transactions;

public sealed record SubTransaction
{
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    [JsonPropertyName("transaction_id")]
    public required string TransactionId { get; init; }

    /// <summary>
    /// The subtransaction amount
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
    /// If a transfer, the account_id which the subtransaction transfers to
    /// </summary>
    [JsonPropertyName("transfer_account_id")]
    public required Guid? TransferAccountId { get; init; }

    /// <summary>
    /// If a transfer, the id of transaction on the other side of the transfer
    /// </summary>
    [JsonPropertyName("transfer_transaction_id")]
    public required string? TransferTransactionId { get; init; }

    /// <summary>
    /// Whether the subtransaction has been deleted. Deleted subtransactions will only be included in delta requests.
    /// </summary>
    [JsonPropertyName("deleted")]
    public required bool Deleted { get; init; }
}