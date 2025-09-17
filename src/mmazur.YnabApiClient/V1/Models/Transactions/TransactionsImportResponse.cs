#pragma warning disable IDE0044 // Add readonly modifier

using System.Text.Json.Serialization;

namespace mmazur.YnabApiClient.V1.Models.Transactions;

public sealed record TransactionsImportResponse
{
    /// <summary>
    /// The list of transaction ids that were imported.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("transaction_ids")]
    private List<string> _transactionIds = [];

    public IReadOnlyList<string> TransactionIds => _transactionIds.AsReadOnly();
}