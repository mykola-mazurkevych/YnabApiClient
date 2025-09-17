using mmazur.YnabApiClient.Infrastructure;
using mmazur.YnabApiClient.V1.Clients.Accounts;
using mmazur.YnabApiClient.V1.Clients.Categories;
using mmazur.YnabApiClient.V1.Clients.Months;
using mmazur.YnabApiClient.V1.Clients.PayeeLocations;
using mmazur.YnabApiClient.V1.Clients.Payees;
using mmazur.YnabApiClient.V1.Clients.Transactions;
using mmazur.YnabApiClient.V1.Interfaces.Accounts;
using mmazur.YnabApiClient.V1.Interfaces.Budgets;
using mmazur.YnabApiClient.V1.Interfaces.Categories;
using mmazur.YnabApiClient.V1.Interfaces.Months;
using mmazur.YnabApiClient.V1.Interfaces.PayeeLocations;
using mmazur.YnabApiClient.V1.Interfaces.Payees;
using mmazur.YnabApiClient.V1.Interfaces.Transactions;
using mmazur.YnabApiClient.V1.Models.Budgets;

namespace mmazur.YnabApiClient.V1.Clients.Budgets;

internal sealed class YnabV1BudgetApiClient
    : YnabApiClientBase, IYnabV1BudgetApiClient
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly Uri _resourceUri;
    private readonly string _bearerToken;

    public YnabV1BudgetApiClient(IHttpClientFactory httpClientFactory, Uri baseUri, Guid budgetId, string bearerToken)
        : base(httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
        _resourceUri = new Uri(baseUri, $"{budgetId}/");
        _bearerToken = bearerToken;
    }

    public YnabV1BudgetApiClient(IHttpClientFactory httpClientFactory, Uri baseUri, BudgetType budgetType, string bearerToken)
        : base(httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
        _resourceUri = new Uri(baseUri, budgetType.ToCustomString() + '/');
        _bearerToken = bearerToken;
    }

    public IYnabV1AccountsApiClient Accounts => new YnabV1AccountsApiClient(_httpClientFactory, _resourceUri, _bearerToken);

    public IYnabV1CategoriesApiClient Categories => new YnabV1CategoriesApiClient(_httpClientFactory, _resourceUri, _bearerToken);

    public IYnabV1MonthsApiClient Months => new YnabV1MonthsApiClient(_httpClientFactory, _resourceUri, _bearerToken);

    public IYnabV1PayeesApiClient Payees => new YnabV1PayeesApiClient(_httpClientFactory, _resourceUri, _bearerToken);
    public IYnabV1PayeeLocationsApiClient PayeeLocations => new YnabV1PayeeLocationsApiClient(_httpClientFactory, _resourceUri, _bearerToken);

    public IYnabV1ScheduledTransactionsApiClient ScheduledTransactions => new YnabV1ScheduledTransactionsApiClient(_httpClientFactory, _resourceUri, _bearerToken);
    public IYnabV1TransactionsApiClient Transactions => new YnabV1TransactionsApiClient(_httpClientFactory, _resourceUri, _bearerToken);

    public IYnabV1BudgetSettingsApiClient Settings => new YnabV1BudgetSettingsApiClient(_httpClientFactory, _resourceUri, _bearerToken);

    public Task<BudgetDetailResponse> GetAsync(CancellationToken cancellationToken = default) =>
        this.GetAsync<BudgetDetailResponse>(_resourceUri, null, _bearerToken, cancellationToken);

    public Task<BudgetDetailResponse> GetAsync(long lastKnowledgeOfServer, CancellationToken cancellationToken = default) =>
        this.GetAsync<BudgetDetailResponse>(_resourceUri, new { last_knowledge_of_server = lastKnowledgeOfServer }, _bearerToken, cancellationToken);
}