namespace mmazur.YnabApiClient.V1.Budgets;

public interface IYnabV1BudgetsApiClient :
    IYnabV1BudgetsDefaultApiClient,
    IYnabV1BudgetsGetApiClient,
    IYnabV1BudgetsIndexerApiClient,
    IYnabV1BudgetsLastUsedApiClient;