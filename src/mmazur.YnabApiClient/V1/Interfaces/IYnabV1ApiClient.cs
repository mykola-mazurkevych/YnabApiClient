using mmazur.YnabApiClient.V1.Interfaces.Users;

namespace mmazur.YnabApiClient.V1.Interfaces;

public interface IYnabV1ApiClient
{
    IYnabV1UserApiClient User { get; }
}