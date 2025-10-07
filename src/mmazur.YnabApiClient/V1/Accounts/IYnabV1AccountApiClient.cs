using mmazur.YnabApiClient.V1.Accounts.Models;
using mmazur.YnabApiClient.V1.Transactions;

namespace mmazur.YnabApiClient.V1.Accounts;

public interface IYnabV1AccountApiClient
{
    IYnabV1TransactionsApiClient Transactions { get; }

    /// <summary>
    /// Single account
    /// Returns a single account
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<AccountResponse?> GetAsync(CancellationToken cancellationToken = default);
}