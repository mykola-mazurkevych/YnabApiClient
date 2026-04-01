using Microsoft.Extensions.Logging;

using mmazur.YnabApiClient.V1.Budgets;
using mmazur.YnabApiClient.V1.Users;

namespace mmazur.YnabApiClient.V1;

internal sealed class YnabV1ApiClient(HttpClient httpClient, ILogger? logger) :
    IYnabV1ApiClient
{
    private readonly Uri _baseUri = new("v1/", UriKind.Relative);

    public IYnabV1BudgetsApiClient Budgets => new YnabV1BudgetsApiClient(httpClient, _baseUri, logger);
    public IYnabV1UserApiClient User => new YnabV1UserApiClient(httpClient, _baseUri, logger);
}