#pragma warning disable CA1043 // Use integral or string argument for indexers
#pragma warning disable CA1716 // Identifiers should not match keywords

namespace mmazur.YnabApiClient.V1.Budgets;

public interface IYnabV1BudgetsApiClient
    : IYnabV1BudgetsGetApiClient
{
    IYnabV1BudgetApiClient this[Guid budgetId] { get; }

    IYnabV1BudgetApiClient Default { get; }
    IYnabV1BudgetApiClient LastUsed { get; }
}