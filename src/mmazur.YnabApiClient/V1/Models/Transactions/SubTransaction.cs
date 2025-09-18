using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Transactions;

public sealed record SubTransaction
{
    [JsonPropertyName("id")]
    [JsonRequired]
    public required string Id { get; init; }

    [JsonPropertyName("transaction_id")]
    [JsonRequired]
    public required string TransactionId { get; init; }

    /// <summary>
    /// The subtransaction amount
    /// </summary>
    [JsonPropertyName("amount")]
    [JsonRequired]
    public required decimal Amount { get; init; }

    [JsonPropertyName("memo")]
    public string? Memo { get; init; }

    [JsonPropertyName("payee_id")]
    public Guid? PayeeId { get; init; }

    [JsonPropertyName("payee_name")]
    public string? PayeeName { get; init; }

    [JsonPropertyName("category_id")]
    public Guid? CategoryId { get; init; }

    [JsonPropertyName("category_name")]
    public string? CategoryName { get; init; }

    /// <summary>
    /// If a transfer, the account_id which the subtransaction transfers to
    /// </summary>
    [JsonPropertyName("transfer_account_id")]
    public Guid? TransferAccountId { get; init; }

    /// <summary>
    /// If a transfer, the id of transaction on the other side of the transfer
    /// </summary>
    [JsonPropertyName("transfer_transaction_id")]
    public string? TransferTransactionId { get; init; }

    /// <summary>
    /// Whether the subtransaction has been deleted. Deleted subtransactions will only be included in delta requests.
    /// </summary>
    [JsonPropertyName("deleted")]
    [JsonRequired]
    public required bool Deleted { get; init; }
}