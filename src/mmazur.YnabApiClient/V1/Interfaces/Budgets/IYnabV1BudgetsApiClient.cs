#pragma warning disable CA1043 // Use integral or string argument for indexers

using mmazur.YnabApiClient.V1.Models.Budgets;

namespace mmazur.YnabApiClient.V1.Interfaces.Budgets;

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
    Task<BudgetsResponse> GetAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// List budgets
    /// Returns budgets list with summary information including accounts
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<BudgetWithAccountsResponse> GetWithAccountsAsync(CancellationToken cancellationToken = default);
}