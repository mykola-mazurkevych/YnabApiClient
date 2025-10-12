using mmazur.YnabApiClient.V1.Transactions;

namespace mmazur.YnabApiClient.V1.Payees;

public interface IYnabV1PayeeTransactionsApiClient
{
    IYnabV1TransactionsGetApiClient Transactions { get; }
}