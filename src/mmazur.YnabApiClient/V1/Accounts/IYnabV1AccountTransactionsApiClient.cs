using mmazur.YnabApiClient.V1.Transactions;

namespace mmazur.YnabApiClient.V1.Accounts;

public interface IYnabV1AccountTransactionsApiClient
{
    IYnabV1TransactionsGetApiClient Transactions { get; }
}