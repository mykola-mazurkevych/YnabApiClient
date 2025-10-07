#pragma warning disable CA1043 // Use integral or string argument for indexers

namespace mmazur.YnabApiClient.V1.PayeeLocations;

public interface IYnabV1PayeeLocationsApiClient
    : IYnabV1PayeeLocationsGetApiClient
{
    IYnabV1PayeeLocationApiClient this[Guid payeeLocationId] { get; }
}