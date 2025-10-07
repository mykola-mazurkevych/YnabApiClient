using Microsoft.Extensions.Logging;

using mmazur.YnabApiClient.V1;

namespace mmazur.YnabApiClient;

internal sealed class YnabApiClient(IHttpClientFactory httpClientFactory, ILogger? logger, YnabApiClientOptions options)
    : IYnabApiClient
{
    public IYnabV1ApiClient V1 => new YnabV1ApiClient(httpClientFactory, logger, options.BaseUri, options.BearerToken);
}