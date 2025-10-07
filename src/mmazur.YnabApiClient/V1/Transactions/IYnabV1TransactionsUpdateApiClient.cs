using mmazur.YnabApiClient.V1.Transactions.Models;

namespace mmazur.YnabApiClient.V1.Transactions;

public interface IYnabV1TransactionsUpdateApiClient
{
    /// <summary>
    /// Update single transaction
    /// Updates single transactions, by id or import_id.
    /// </summary>
    /// <param name="transaction">
    /// The transaction to update.
    /// The transaction must have either an id or import_id specified.
    /// If id is specified as null an import_id value can be provided which will allow transaction(s) to be updated by its import_id.
    /// If an id is specified, it will always be used for lookup.
    /// You should not specify both id and import_id.
    /// Updating an import_id on an existing transaction is not allowed; if an import_id is specified, it will only be used to look up the transaction.
    /// </param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<SaveTransactionResponse> UpdateAsync(SaveTransactionWithIdOrImportId transaction, CancellationToken cancellationToken = default);

    /// <summary>
    /// Update multiple transactions
    /// Updates multiple transactions, by id or import_id.
    /// </summary>
    /// <param name="transactions">
    /// The transactions to update.
    /// Each transaction must have either an id or import_id specified.
    /// If id is specified as null an import_id value can be provided which will allow transaction(s) to be updated by its import_id.
    /// If an id is specified, it will always be used for lookup.
    /// You should not specify both id and import_id.
    /// Updating an import_id on an existing transaction is not allowed; if an import_id is specified, it will only be used to look up the transaction.
    /// </param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<SaveTransactionsResponse> UpdateAsync(IEnumerable<SaveTransactionWithIdOrImportId> transactions, CancellationToken cancellationToken = default);
}