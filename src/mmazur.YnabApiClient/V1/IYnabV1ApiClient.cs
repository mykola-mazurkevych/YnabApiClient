using mmazur.YnabApiClient.V1.Budgets;
using mmazur.YnabApiClient.V1.Users;

namespace mmazur.YnabApiClient.V1;

public interface IYnabV1ApiClient
{
    IYnabV1BudgetsApiClient Budgets { get; }
    IYnabV1UserApiClient User { get; }
}