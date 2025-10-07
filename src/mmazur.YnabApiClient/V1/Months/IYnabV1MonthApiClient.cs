using mmazur.YnabApiClient.V1.Categories;
using mmazur.YnabApiClient.V1.Transactions;

namespace mmazur.YnabApiClient.V1.Months;

public interface IYnabV1MonthApiClient
    : IYnabV1MonthGetApiClient
{
    IYnabV1CategoriesGetApiClient Categories { get; }
    IYnabV1TransactionsGetApiClient Transactions { get; }
}