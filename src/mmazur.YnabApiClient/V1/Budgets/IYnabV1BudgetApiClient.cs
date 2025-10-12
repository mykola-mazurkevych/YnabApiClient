namespace mmazur.YnabApiClient.V1.Budgets;

public interface IYnabV1BudgetApiClient :
    IYnabV1BudgetAccountsApiClient,
    IYnabV1BudgetBudgetSettingsApiClient,
    IYnabV1BudgetCategoriesApiClient,
    IYnabV1BudgetGetApiClient,
    IYnabV1BudgetMonthsApiClient,
    IYnabV1BudgetPayeeLocationsApiClient,
    IYnabV1BudgetPayeesApiClient,
    IYnabV1BudgetScheduledTransactionsApiClient,
    IYnabV1BudgetTransactionsApiClient;