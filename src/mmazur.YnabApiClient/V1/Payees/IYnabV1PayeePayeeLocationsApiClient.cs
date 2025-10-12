using mmazur.YnabApiClient.V1.PayeeLocations;

namespace mmazur.YnabApiClient.V1.Payees;

public interface IYnabV1PayeePayeeLocationsApiClient
{
    IYnabV1PayeeLocationsGetApiClient Locations { get; }
}