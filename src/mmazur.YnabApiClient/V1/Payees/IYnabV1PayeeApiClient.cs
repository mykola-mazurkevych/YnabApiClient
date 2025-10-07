using mmazur.YnabApiClient.V1.PayeeLocations;
using mmazur.YnabApiClient.V1.Transactions;

namespace mmazur.YnabApiClient.V1.Payees;

public interface IYnabV1PayeeApiClient
    : IYnabV1PayeeGetApiClient, IYnabV1PayeeUpdateApiClient
{
    IYnabV1PayeeLocationsGetApiClient Locations { get; }
    IYnabV1TransactionsGetApiClient Transactions { get; }
}