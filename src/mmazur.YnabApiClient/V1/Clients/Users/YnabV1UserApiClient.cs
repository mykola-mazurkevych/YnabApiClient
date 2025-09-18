using Microsoft.Extensions.Logging;

using mmazur.YnabApiClient.Infrastructure;
using mmazur.YnabApiClient.V1.Interfaces.Users;
using mmazur.YnabApiClient.V1.Models.Users;

namespace mmazur.YnabApiClient.V1.Clients.Users;

internal sealed class YnabV1UserApiClient(IHttpClientFactory httpClientFactory, ILogger? logger, Uri baseUri, string bearerToken)
    : YnabApiClientBase(httpClientFactory, logger), IYnabV1UserApiClient
{
    private readonly Uri _resourceUri = new(baseUri, "user/");

    public Task<UserResponse?> GetAsync(CancellationToken cancellationToken = default) =>
        this.GetAsync<UserResponse>(_resourceUri, bearerToken, cancellationToken);
}