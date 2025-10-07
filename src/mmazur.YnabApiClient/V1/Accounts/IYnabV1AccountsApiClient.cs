#pragma warning disable CA1043 // Use integral or string argument for indexers

namespace mmazur.YnabApiClient.V1.Accounts;

public interface IYnabV1AccountsApiClient
    : IYnabV1AccountsGetApiClient, IYnabV1AccountsCreateApiClient
{
    IYnabV1AccountApiClient this[Guid accountId] { get; }
}