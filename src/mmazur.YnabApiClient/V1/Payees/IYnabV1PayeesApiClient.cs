#pragma warning disable CA1043 // Use integral or string argument for indexers

namespace mmazur.YnabApiClient.V1.Payees;

public interface IYnabV1PayeesApiClient
    : IYnabV1PayeesGetApiClient
{
    IYnabV1PayeeApiClient this[Guid payeeId] { get; }
}