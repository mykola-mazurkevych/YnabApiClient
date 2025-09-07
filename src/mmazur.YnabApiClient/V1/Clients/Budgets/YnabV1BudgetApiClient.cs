using mmazur.YnabApiClient.Extensions;
using mmazur.YnabApiClient.Infrastructure;
using mmazur.YnabApiClient.V1.Clients.Accounts;
using mmazur.YnabApiClient.V1.Clients.PayeeLocations;
using mmazur.YnabApiClient.V1.Clients.Payees;
using mmazur.YnabApiClient.V1.Interfaces.Accounts;
using mmazur.YnabApiClient.V1.Interfaces.Budgets;
using mmazur.YnabApiClient.V1.Interfaces.PayeeLocations;
using mmazur.YnabApiClient.V1.Interfaces.Payees;
using mmazur.YnabApiClient.V1.Models.Budgets;

namespace mmazur.YnabApiClient.V1.Clients.Budgets;

internal sealed class YnabV1BudgetApiClient
    : YnabApiClientBase, IYnabV1BudgetApiClient
{
    public YnabV1BudgetApiClient(IHttpClientFactory httpClientFactory, Uri baseUri, Guid budgetId, string bearerToken)
        : base(httpClientFactory)
    {
        var resourceUri = new Uri(baseUri, $"{budgetId}/");

        this.Accounts = new YnabV1AccountsApiClient(httpClientFactory, resourceUri, bearerToken);
        this.Payees = new YnabV1PayeesApiClient(httpClientFactory, resourceUri, bearerToken);
        this.PayeeLocations = new YnabV1PayeeLocationsApiClient(httpClientFactory, resourceUri, bearerToken);
        this.Settings = new YnabV1BudgetSettingsApiClient(httpClientFactory, resourceUri, bearerToken);
    }

    public YnabV1BudgetApiClient(IHttpClientFactory httpClientFactory, Uri baseUri, BudgetType budgetType, string bearerToken)
        : base(httpClientFactory)
    {
        var resourceUri = new Uri(baseUri, budgetType.ToCustomString() + '/');

        this.Accounts = new YnabV1AccountsApiClient(httpClientFactory, resourceUri, bearerToken);
        this.Payees = new YnabV1PayeesApiClient(httpClientFactory, resourceUri, bearerToken);
        this.PayeeLocations = new YnabV1PayeeLocationsApiClient(httpClientFactory, resourceUri, bearerToken);
        this.Settings = new YnabV1BudgetSettingsApiClient(httpClientFactory, resourceUri, bearerToken);
    }

    public IYnabV1AccountsApiClient Accounts { get; }

    public IYnabV1PayeesApiClient Payees { get; set; }
    public IYnabV1PayeeLocationsApiClient PayeeLocations { get; set; }

    public IYnabV1BudgetSettingsApiClient Settings { get; }
}