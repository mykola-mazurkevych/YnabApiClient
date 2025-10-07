using mmazur.YnabApiClient.V1.Accounts;
using mmazur.YnabApiClient.V1.Categories;
using mmazur.YnabApiClient.V1.Months;
using mmazur.YnabApiClient.V1.PayeeLocations;
using mmazur.YnabApiClient.V1.Payees;
using mmazur.YnabApiClient.V1.Transactions;

namespace mmazur.YnabApiClient.V1.Budgets;

public interface IYnabV1BudgetApiClient
    : IYnabV1BudgetGetApiClient
{
    IYnabV1AccountsApiClient Accounts { get; }

    IYnabV1CategoriesApiClient Categories { get; }

    IYnabV1MonthsApiClient Months { get; }

    IYnabV1PayeesApiClient Payees { get; }
    IYnabV1PayeeLocationsApiClient PayeeLocations { get; }

    IYnabV1ScheduledTransactionsApiClient ScheduledTransactions { get; }
    IYnabV1TransactionsApiClient Transactions { get; }

    IYnabV1BudgetSettingsApiClient Settings { get; }
}