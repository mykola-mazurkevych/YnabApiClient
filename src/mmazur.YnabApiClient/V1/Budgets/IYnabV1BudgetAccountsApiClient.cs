using mmazur.YnabApiClient.V1.Accounts;

namespace mmazur.YnabApiClient.V1.Budgets;

public interface IYnabV1BudgetAccountsApiClient
{
    IYnabV1AccountsApiClient Accounts { get; }
}