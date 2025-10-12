using Microsoft.Extensions.Logging;

using mmazur.YnabApiClient.V1.Budgets.Models;
using mmazur.YnabApiClient.V1.Common;

namespace mmazur.YnabApiClient.V1.Budgets;

internal sealed class YnabV1BudgetSettingsApiClient(IHttpClientFactory httpClientFactory, ILogger? logger, Uri baseUri, string bearerToken) :
    YnabApiClientBase(httpClientFactory, logger),
    IYnabV1BudgetSettingsApiClient
{
    private readonly Uri _resourceUri = new(baseUri, "settings/");

    public Task<BudgetSettingsResponse?> GetAsync(CancellationToken cancellationToken = default) =>
        this.GetAsync<BudgetSettingsResponse>(_resourceUri, bearerToken, cancellationToken);
}