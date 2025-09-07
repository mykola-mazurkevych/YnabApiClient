using mmazur.YnabApiClient.V1.Interfaces.Budgets;
using mmazur.YnabApiClient.V1.Interfaces.Users;

namespace mmazur.YnabApiClient.V1.Interfaces;

public interface IYnabV1ApiClient
{
    IYnabV1BudgetsApiClient Budgets { get; }
    IYnabV1UserApiClient User { get; }
}