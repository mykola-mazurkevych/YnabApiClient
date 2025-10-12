namespace mmazur.YnabApiClient.V1.PayeeLocations;

public interface IYnabV1PayeeLocationsPayeeLocationApiClient
{
    IYnabV1PayeeLocationApiClient this[Guid payeeLocationId] { get; }
}