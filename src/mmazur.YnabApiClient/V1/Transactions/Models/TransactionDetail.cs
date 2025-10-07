#pragma warning disable IDE0044 // Add readonly modifier

using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Transactions.Models;

public sealed record TransactionDetail
{
    /// <summary>
    /// If a split transaction, the subtransactions.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("subtransactions")]
    private List<SubTransaction> _subTransactions = [];

    [JsonPropertyName("id")]
    [JsonRequired]
    public required string Id { get; init; }

    /// <summary>
    /// The transaction date in ISO format (e.g. 2016-12-01)
    /// </summary>
    [JsonPropertyName("date")]
    [JsonRequired]
    public required DateOnly Date { get; init; }

    /// <summary>
    /// The transaction amount
    /// </summary>
    [JsonPropertyName("amount")]
    [JsonRequired]
    public required decimal Amount { get; init; }

    [JsonPropertyName("memo")]
    public string? Memo { get; init; }

    [JsonPropertyName("cleared")]
    [JsonRequired]
    public required TransactionClearedStatus ClearedStatus { get; init; }

    /// <summary>
    /// Whether the transaction is approved
    /// </summary>
    [JsonPropertyName("approved")]
    [JsonRequired]
    public required bool Approved { get; init; }

    [JsonPropertyName("flag_color")]
    public TransactionFlagColor? FlagColor { get; init; }

    [JsonPropertyName("flag_name")]
    public string? FlagName { get; init; }

    [JsonPropertyName("account_id")]
    [JsonRequired]
    public required Guid AccountId { get; init; }

    [JsonPropertyName("account_name")]
    public required string AccountName { get; init; }

    [JsonPropertyName("payee_id")]
    public Guid? PayeeId { get; init; }

    [JsonPropertyName("payee_name")]
    public string? PayeeName { get; init; }

    [JsonPropertyName("category_id")]
    public Guid? CategoryId { get; init; }

    /// <summary>
    /// The name of the category.
    /// If a split transaction, this will be 'Split'.
    /// </summary>
    [JsonPropertyName("category_name")]
    public string? CategoryName { get; init; }

    /// <summary>
    /// If a transfer transaction, the account to which it transfers
    /// </summary>
    [JsonPropertyName("transfer_account_id")]
    public Guid? TransferAccountId { get; init; }

    /// <summary>
    /// If a transfer transaction, the id of transaction on the other side of the transfer
    /// </summary>
    [JsonPropertyName("transfer_transaction_id")]
    public string? TransferTransactionId { get; init; }

    /// <summary>
    /// If transaction is matched, the id of the matched transaction
    /// </summary>
    [JsonPropertyName("matched_transaction_id")]
    public string? MatchedTransactionId { get; init; }

    /// <summary>
    /// If the transaction was imported, this field is a unique (by account) import identifier.
    /// If this transaction was imported through File Based Import or Direct Import and not through the API, the import_id will have the format: 'YNAB:[milliunit_amount]:[iso_date]:[occurrence]'.
    /// For example, a transaction dated 2015-12-30 in the amount of -$294.23 USD would have an import_id of 'YNAB:-294230:2015-12-30:1'.
    /// If a second transaction on the same account was imported and had the same date and same amount, its import_id would be 'YNAB:-294230:2015-12-30:2'.
    /// </summary>
    [JsonPropertyName("import_id")]
    public string? ImportId { get; init; }

    /// <summary>
    /// If the transaction was imported, the payee name that was used when importing and before applying any payee rename rules
    /// </summary>
    [JsonPropertyName("import_payee_name")]
    public string? ImportPayeeName { get; init; }

    /// <summary>
    /// If the transaction was imported, the original payee name as it appeared on the statement
    /// </summary>
    [JsonPropertyName("import_payee_name_original")]
    public string? ImportPayeeNameOriginal { get; init; }

    /// <summary>
    /// If the transaction is a debt/loan account transaction, the type of transaction
    /// </summary>
    [JsonPropertyName("debt_transaction_type")]
    public DebtTransactionType? DebtTransactionType { get; init; }

    /// <summary>
    /// Whether the transaction has been deleted. Deleted transactions will only be included in delta requests.
    /// </summary>
    [JsonPropertyName("deleted")]
    [JsonRequired]
    public required bool Deleted { get; init; }

    [JsonIgnore]
    public IReadOnlyList<SubTransaction> SubTransactions => _subTransactions.AsReadOnly();
}