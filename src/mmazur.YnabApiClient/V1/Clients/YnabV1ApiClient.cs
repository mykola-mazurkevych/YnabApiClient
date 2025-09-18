using Microsoft.Extensions.Logging;

using mmazur.YnabApiClient.V1.Clients.Budgets;
using mmazur.YnabApiClient.V1.Clients.Users;
using mmazur.YnabApiClient.V1.Interfaces;
using mmazur.YnabApiClient.V1.Interfaces.Budgets;
using mmazur.YnabApiClient.V1.Interfaces.Users;

namespace mmazur.YnabApiClient.V1.Clients;

internal sealed class YnabV1ApiClient(IHttpClientFactory httpClientFactory, ILogger? logger, Uri baseUri, string bearerToken)
    : IYnabV1ApiClient
{
    private readonly Uri _baseUri = new(baseUri, "v1/");

    public IYnabV1BudgetsApiClient Budgets => new YnabV1BudgetsApiClient(httpClientFactory, logger, _baseUri, bearerToken);
    public IYnabV1UserApiClient User => new YnabV1UserApiClient(httpClientFactory, logger, _baseUri, bearerToken);
}