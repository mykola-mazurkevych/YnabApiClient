#pragma warning disable CA1716 // Identifiers should not match keywords

using mmazur.YnabApiClient.V1.Budgets.Models;

namespace mmazur.YnabApiClient.V1.Budgets;

public interface IYnabV1BudgetsApiClient
{
    IYnabV1BudgetApiClient this[Guid budgetId] { get; }

    IYnabV1BudgetApiClient Default { get; }

    IYnabV1BudgetApiClient LastUsed { get; }

    /// <summary>
    /// List budgets
    /// Returns budgets list with summary information
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<BudgetSummaryResponse?> GetAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// List budgets
    /// Returns budgets list with summary information including accounts
    /// </summary>
    /// <param name="includeAccounts">Whether to include the list of budget accounts</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<BudgetSummaryResponse?> GetAsync(bool includeAccounts, CancellationToken cancellationToken = default);
}