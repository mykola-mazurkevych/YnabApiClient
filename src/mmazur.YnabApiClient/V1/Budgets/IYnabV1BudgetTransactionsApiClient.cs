using mmazur.YnabApiClient.V1.Transactions;

namespace mmazur.YnabApiClient.V1.Budgets;

public interface IYnabV1BudgetTransactionsApiClient
{
    IYnabV1TransactionsApiClient Transactions { get; }
}