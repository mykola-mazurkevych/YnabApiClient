using mmazur.YnabApiClient.V1.Interfaces.Accounts;
using mmazur.YnabApiClient.V1.Interfaces.PayeeLocations;
using mmazur.YnabApiClient.V1.Interfaces.Payees;

namespace mmazur.YnabApiClient.V1.Interfaces.Budgets;

public interface IYnabV1BudgetApiClient
{
    IYnabV1AccountsApiClient Accounts { get; }

    IYnabV1PayeesApiClient Payees { get; }
    IYnabV1PayeeLocationsApiClient PayeeLocations { get; }

    IYnabV1BudgetSettingsApiClient Settings { get; }
}