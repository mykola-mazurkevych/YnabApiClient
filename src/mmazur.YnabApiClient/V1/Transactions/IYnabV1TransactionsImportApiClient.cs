using mmazur.YnabApiClient.V1.Transactions.Models;

namespace mmazur.YnabApiClient.V1.Transactions;

public interface IYnabV1TransactionsImportApiClient
{
    /// <summary>
    /// Import transactions
    /// Imports available transactions on all linked accounts for the given budget.
    /// Linked accounts allow transactions to be imported directly from a specified financial institution and this endpoint initiates that import.
    /// Sending a request to this endpoint is the equivalent of clicking "Import" on each account in the web application or tapping the "New Transactions" banner in the mobile applications.
    /// The response for this endpoint contains the transaction ids that have been imported.
    /// </summary>
    /// <param name="transactions"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<TransactionsImportResponse> ImportAsync(IEnumerable<object> transactions, CancellationToken cancellationToken = default); // TODO: Investigate data to be sent (collection of transactions, file, etc.)
}