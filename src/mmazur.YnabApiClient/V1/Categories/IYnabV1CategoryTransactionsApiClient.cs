using mmazur.YnabApiClient.V1.Transactions;

namespace mmazur.YnabApiClient.V1.Categories;

public interface IYnabV1CategoryTransactionsApiClient
{
    IYnabV1TransactionsGetApiClient Transactions { get; }
}