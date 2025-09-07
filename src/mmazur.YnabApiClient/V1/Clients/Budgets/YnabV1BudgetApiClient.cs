using mmazur.YnabApiClient.Extensions;
using mmazur.YnabApiClient.Infrastructure;
using mmazur.YnabApiClient.V1.Interfaces.Budgets;
using mmazur.YnabApiClient.V1.Models.Budgets;

namespace mmazur.YnabApiClient.V1.Clients.Budgets;

internal sealed class YnabV1BudgetApiClient
    : YnabApiClientBase, IYnabV1BudgetApiClient
{
    public YnabV1BudgetApiClient(IHttpClientFactory httpClientFactory, Uri baseUri, Guid budgetId, string bearerToken)
        : base(httpClientFactory)
    {
        var resourceUri = new Uri(baseUri, $"{budgetId}/");
        this.Settings = new YnabV1BudgetSettingsApiClient(httpClientFactory, resourceUri, bearerToken);
    }

    public YnabV1BudgetApiClient(IHttpClientFactory httpClientFactory, Uri baseUri, BudgetType budgetType, string bearerToken)
        : base(httpClientFactory)
    {
        var resourceUri = new Uri(baseUri, budgetType.ToCustomString() + '/');
        this.Settings = new YnabV1BudgetSettingsApiClient(httpClientFactory, resourceUri, bearerToken);
    }

    public IYnabV1BudgetSettingsApiClient Settings { get; }
}