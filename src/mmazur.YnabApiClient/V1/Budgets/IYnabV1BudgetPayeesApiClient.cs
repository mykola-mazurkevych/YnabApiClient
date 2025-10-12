using mmazur.YnabApiClient.V1.Payees;

namespace mmazur.YnabApiClient.V1.Budgets;

public interface IYnabV1BudgetPayeesApiClient
{
    IYnabV1PayeesApiClient Payees { get; }
}