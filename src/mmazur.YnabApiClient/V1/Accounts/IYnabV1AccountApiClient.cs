using mmazur.YnabApiClient.V1.Transactions;

namespace mmazur.YnabApiClient.V1.Accounts;

public interface IYnabV1AccountApiClient
    : IYnabV1AccountGetApiClient
{
    IYnabV1TransactionsGetApiClient Transactions { get; }
}