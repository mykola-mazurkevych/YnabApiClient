using mmazur.YnabApiClient.V1;

namespace mmazur.YnabApiClient;

public interface IYnabApiClient
{
    IYnabV1ApiClient V1 { get; }
}