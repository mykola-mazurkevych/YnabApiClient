using mmazur.YnabApiClient.V1.Interfaces.Accounts;

namespace mmazur.YnabApiClient.V1.Interfaces.Budgets;

public interface IYnabV1BudgetApiClient
{
    IYnabV1AccountsApiClient Accounts { get; }
    IYnabV1BudgetSettingsApiClient Settings { get; }
}