using mmazur.YnabApiClient.Infrastructure;
using mmazur.YnabApiClient.V1.Interfaces.Users;
using mmazur.YnabApiClient.V1.Models.Users;

namespace mmazur.YnabApiClient.V1.Clients.Users;

internal sealed class YnabV1UserApiClient(IHttpClientFactory httpClientFactory, Uri baseUri, string bearerToken)
    : YnabApiClientBase(httpClientFactory), IYnabV1UserApiClient
{
    private readonly Uri _resourceUri = new(baseUri, "user/");

    public Task<UserResponse> GetAsync(CancellationToken cancellationToken = default)
        => this.GetDataAsync<UserResponse>(_resourceUri, null, bearerToken, cancellationToken);
}