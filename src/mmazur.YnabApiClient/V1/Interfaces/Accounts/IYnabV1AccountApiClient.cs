using mmazur.YnabApiClient.V1.Interfaces.Transactions;
using mmazur.YnabApiClient.V1.Models.Accounts;

namespace mmazur.YnabApiClient.V1.Interfaces.Accounts;

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