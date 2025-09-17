#pragma warning disable IDE0044 // Add readonly modifier

using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Transactions;

public sealed record TransactionDetail
{
    /// <summary>
    /// If a split transaction, the subtransactions.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("subtransactions")]
    private List<SubTransaction> _subTransactions = [];

    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>
    /// The transaction date in ISO format (e.g. 2016-12-01)
    /// </summary>
    [JsonPropertyName("date")]
    public required DateOnly Date { get; init; }

    /// <summary>
    /// The transaction amount
    /// </summary>
    [JsonPropertyName("amount")]
    public required decimal Amount { get; init; }

    [JsonPropertyName("memo")]
    public required string? Memo { get; init; }

    [JsonPropertyName("cleared")]
    public required TransactionClearedStatus ClearedStatus { get; init; }

    /// <summary>
    /// Whether the transaction is approved
    /// </summary>
    [JsonPropertyName("approved")]
    public required bool Approved { get; init; }

    [JsonPropertyName("flag_color")]
    public required TransactionFlagColor? FlagColor { get; init; }

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
    /// The name of the category.
    /// If a split transaction, this will be 'Split'.
    /// </summary>
    [JsonPropertyName("category_name")]
    public required string? CategoryName { get; init; }

    /// <summary>
    /// If a transfer transaction, the account to which it transfers
    /// </summary>
    [JsonPropertyName("transfer_account_id")]
    public required Guid? TransferAccountId { get; init; }

    /// <summary>
    /// If a transfer transaction, the id of transaction on the other side of the transfer
    /// </summary>
    [JsonPropertyName("transfer_transaction_id")]
    public required string? TransferTransactionId { get; init; }

    /// <summary>
    /// If transaction is matched, the id of the matched transaction
    /// </summary>
    [JsonPropertyName("matched_transaction_id")]
    public required string? MatchedTransactionId { get; init; }

    /// <summary>
    /// If the transaction was imported, this field is a unique (by account) import identifier.
    /// If this transaction was imported through File Based Import or Direct Import and not through the API, the import_id will have the format: 'YNAB:[milliunit_amount]:[iso_date]:[occurrence]'.
    /// For example, a transaction dated 2015-12-30 in the amount of -$294.23 USD would have an import_id of 'YNAB:-294230:2015-12-30:1'.
    /// If a second transaction on the same account was imported and had the same date and same amount, its import_id would be 'YNAB:-294230:2015-12-30:2'.
    /// </summary>
    [JsonPropertyName("import_id")]
    public required string? ImportId { get; init; }

    /// <summary>
    /// If the transaction was imported, the payee name that was used when importing and before applying any payee rename rules
    /// </summary>
    [JsonPropertyName("import_payee_name")]
    public required string? ImportPayeeName { get; init; }

    /// <summary>
    /// If the transaction was imported, the original payee name as it appeared on the statement
    /// </summary>
    [JsonPropertyName("import_payee_name_original")]
    public required string? ImportPayeeNameOriginal { get; init; }

    /// <summary>
    /// If the transaction is a debt/loan account transaction, the type of transaction
    /// </summary>
    [JsonPropertyName("debt_transaction_type")]
    public required DebtTransactionType? DebtTransactionType { get; init; }

    /// <summary>
    /// Whether the transaction has been deleted. Deleted transactions will only be included in delta requests.
    /// </summary>
    [JsonPropertyName("deleted")]
    public required bool Deleted { get; init; }

    public IReadOnlyList<SubTransaction> SubTransactions => _subTransactions.AsReadOnly();
}