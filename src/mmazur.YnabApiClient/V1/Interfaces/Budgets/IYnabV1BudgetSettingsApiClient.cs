using mmazur.YnabApiClient.V1.Models.Budgets;

namespace mmazur.YnabApiClient.V1.Interfaces.Budgets;

public interface IYnabV1BudgetSettingsApiClient
{
    /// <summary>
    /// Budget settings
    /// Returns settings for a budget
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<BudgetSettingsResponse?> GetAsync(CancellationToken cancellationToken = default);
}