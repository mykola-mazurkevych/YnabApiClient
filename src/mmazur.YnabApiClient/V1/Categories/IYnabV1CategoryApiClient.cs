using mmazur.YnabApiClient.V1.Transactions;

namespace mmazur.YnabApiClient.V1.Categories;

public interface IYnabV1CategoryApiClient
    : IYnabV1CategoryGetApiClient, IYnabV1CategoryUpdateApiClient
{
    IYnabV1TransactionsGetApiClient Transactions { get; }
}