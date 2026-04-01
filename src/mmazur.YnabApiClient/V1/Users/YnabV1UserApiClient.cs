using Microsoft.Extensions.Logging;

using mmazur.YnabApiClient.Extensions;
using mmazur.YnabApiClient.V1.Common;
using mmazur.YnabApiClient.V1.Users.Models;

namespace mmazur.YnabApiClient.V1.Users;

internal sealed class YnabV1UserApiClient(HttpClient httpClient, Uri parentUri, ILogger? logger) :
    YnabApiClientBase(httpClient, logger),
    IYnabV1UserApiClient
{
    private readonly Uri _resourceUri = parentUri.AppendPath("user/");

    public Task<UserResponse?> GetAsync(CancellationToken cancellationToken = default) =>
        GetAsync<UserResponse>(_resourceUri, cancellationToken);
}