using Microsoft.Extensions.Logging;

using mmazur.YnabApiClient.V1.Common;
using mmazur.YnabApiClient.V1.Users.Models;

namespace mmazur.YnabApiClient.V1.Users;

internal sealed class YnabV1UserApiClient(IHttpClientFactory httpClientFactory, ILogger? logger, Uri baseUri, string bearerToken)
    : YnabApiClientBase(httpClientFactory, logger), IYnabV1UserApiClient
{
    private readonly Uri _resourceUri = new(baseUri, "user/");

    public Task<UserResponse?> GetAsync(CancellationToken cancellationToken = default) =>
        this.GetAsync<UserResponse>(_resourceUri, bearerToken, cancellationToken);
}