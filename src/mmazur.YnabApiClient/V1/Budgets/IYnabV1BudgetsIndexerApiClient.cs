namespace mmazur.YnabApiClient.V1.Budgets;

public interface IYnabV1BudgetsIndexerApiClient
{
    IYnabV1BudgetApiClient this[Guid budgetId] { get; }
}