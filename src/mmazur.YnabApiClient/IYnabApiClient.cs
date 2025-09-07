using mmazur.YnabApiClient.V1.Interfaces;

namespace mmazur.YnabApiClient;

public interface IYnabApiClient
{
    IYnabV1ApiClient V1 { get; }
}