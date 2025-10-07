using mmazur.YnabApiClient.V1.Budgets.Models;

namespace mmazur.YnabApiClient.V1.Budgets;

public interface IYnabV1BudgetSettingsGetApiClient
{
    /// <summary>
    /// Budget settings
    /// Returns settings for a budget
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<BudgetSettingsResponse?> GetAsync(CancellationToken cancellationToken = default);
}