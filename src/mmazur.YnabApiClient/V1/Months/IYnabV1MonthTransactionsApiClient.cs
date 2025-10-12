using mmazur.YnabApiClient.V1.Transactions;

namespace mmazur.YnabApiClient.V1.Months;

public interface IYnabV1MonthTransactionsApiClient
{
    IYnabV1TransactionsGetApiClient Transactions { get; }
}