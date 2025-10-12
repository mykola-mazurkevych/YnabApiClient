using mmazur.YnabApiClient.V1.PayeeLocations;

namespace mmazur.YnabApiClient.V1.Budgets;

public interface IYnabV1BudgetPayeeLocationsApiClient
{
    IYnabV1PayeeLocationsApiClient PayeeLocations { get; }
}