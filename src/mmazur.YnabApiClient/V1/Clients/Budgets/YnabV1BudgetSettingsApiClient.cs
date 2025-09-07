using mmazur.YnabApiClient.Infrastructure;
using mmazur.YnabApiClient.V1.Interfaces.Budgets;
using mmazur.YnabApiClient.V1.Models.Budgets;

namespace mmazur.YnabApiClient.V1.Clients.Budgets;

internal sealed class YnabV1BudgetSettingsApiClient(IHttpClientFactory httpClientFactory, Uri baseUri, string bearerToken)
    : YnabApiClientBase(httpClientFactory), IYnabV1BudgetSettingsApiClient
{
    private readonly Uri _resourceUri = new(baseUri, "settings/");

    public Task<BudgetSettingsResponse> GetAsync(CancellationToken cancellationToken = default) =>
        this.GetDataAsync<BudgetSettingsResponse>(_resourceUri, null, bearerToken, cancellationToken);
}