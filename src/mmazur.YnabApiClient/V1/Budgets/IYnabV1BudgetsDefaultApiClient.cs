#pragma warning disable CA1716 // Identifiers should not match keywords

namespace mmazur.YnabApiClient.V1.Budgets;

public interface IYnabV1BudgetsDefaultApiClient
{
    IYnabV1BudgetApiClient Default { get; }
}