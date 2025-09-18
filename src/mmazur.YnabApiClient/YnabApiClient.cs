using Microsoft.Extensions.Logging;

using mmazur.YnabApiClient.V1.Clients;
using mmazur.YnabApiClient.V1.Interfaces;

namespace mmazur.YnabApiClient;

internal sealed class YnabApiClient(IHttpClientFactory httpClientFactory, ILogger? logger, string bearerToken)
    : IYnabApiClient
{
    private readonly Uri _baseUri = new("https://api.ynab.com/");

    public IYnabV1ApiClient V1 => new YnabV1ApiClient(httpClientFactory, logger, _baseUri, bearerToken);
}