using Microsoft.Extensions.Logging;

using mmazur.YnabApiClient.Extensions;
using mmazur.YnabApiClient.V1.Budgets.Models;
using mmazur.YnabApiClient.V1.Common;

namespace mmazur.YnabApiClient.V1.Budgets;

internal sealed class YnabV1BudgetSettingsApiClient(HttpClient httpClient, Uri parentUri, ILogger? logger) :
    YnabApiClientBase(httpClient, logger),
    IYnabV1BudgetSettingsApiClient
{
    private readonly Uri _resourceUri = parentUri.AppendPath("settings/");

    public Task<BudgetSettingsResponse?> GetAsync(CancellationToken cancellationToken = default) =>
        GetAsync<BudgetSettingsResponse>(_resourceUri, cancellationToken);
}