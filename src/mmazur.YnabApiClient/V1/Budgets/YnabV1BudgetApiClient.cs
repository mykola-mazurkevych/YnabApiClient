using Microsoft.Extensions.Logging;

using mmazur.YnabApiClient.V1.Accounts;
using mmazur.YnabApiClient.V1.Budgets.Models;
using mmazur.YnabApiClient.V1.Categories;
using mmazur.YnabApiClient.V1.Common;
using mmazur.YnabApiClient.V1.Months;
using mmazur.YnabApiClient.V1.PayeeLocations;
using mmazur.YnabApiClient.V1.Payees;
using mmazur.YnabApiClient.V1.Transactions;

namespace mmazur.YnabApiClient.V1.Budgets;

internal sealed class YnabV1BudgetApiClient :
    YnabApiClientBase,
    IYnabV1BudgetApiClient
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger? _logger;
    private readonly Uri _resourceUri;
    private readonly string _bearerToken;

    public YnabV1BudgetApiClient(IHttpClientFactory httpClientFactory, ILogger? logger, Uri baseUri, Guid budgetId, string bearerToken) :
        base(httpClientFactory, logger)
    {
        _httpClientFactory = httpClientFactory;
        _logger = logger;
        _resourceUri = new Uri(baseUri, $"{budgetId}/");
        _bearerToken = bearerToken;
    }

    public YnabV1BudgetApiClient(IHttpClientFactory httpClientFactory, ILogger? logger, Uri baseUri, BudgetType budgetType, string bearerToken) :
        base(httpClientFactory, logger)
    {
        _httpClientFactory = httpClientFactory;
        _logger = logger;
        _resourceUri = new Uri(baseUri, $"{budgetType.ToCustomString()}/");
        _bearerToken = bearerToken;
    }

    public IYnabV1BudgetSettingsApiClient Settings =>
        new YnabV1BudgetSettingsApiClient(_httpClientFactory, _logger, _resourceUri, _bearerToken);

    public IYnabV1AccountsApiClient Accounts =>
        new YnabV1AccountsApiClient(_httpClientFactory, _logger, _resourceUri, _bearerToken);

    public IYnabV1CategoriesApiClient Categories =>
        new YnabV1CategoriesApiClient(_httpClientFactory, _logger, _resourceUri, _bearerToken);

    public IYnabV1MonthsApiClient Months =>
        new YnabV1MonthsApiClient(_httpClientFactory, _logger, _resourceUri, _bearerToken);

    public IYnabV1PayeesApiClient Payees =>
        new YnabV1PayeesApiClient(_httpClientFactory, _logger, _resourceUri, _bearerToken);

    public IYnabV1PayeeLocationsApiClient PayeeLocations =>
        new YnabV1PayeeLocationsApiClient(_httpClientFactory, _logger, _resourceUri, _bearerToken);

    public IYnabV1ScheduledTransactionsApiClient ScheduledTransactions =>
        new YnabV1ScheduledTransactionsApiClient(_httpClientFactory, _logger, _resourceUri, _bearerToken);

    public IYnabV1TransactionsApiClient Transactions =>
        new YnabV1TransactionsApiClient(_httpClientFactory, _logger, _resourceUri, _bearerToken);

    public Task<BudgetDetailResponse?> GetAsync(CancellationToken cancellationToken = default) =>
        this.GetAsync<BudgetDetailResponse>(_resourceUri, _bearerToken, cancellationToken);

    public Task<BudgetDetailResponse?> GetAsync(long lastKnowledgeOfServer, CancellationToken cancellationToken = default) =>
        this.GetAsync<BudgetDetailResponse>(_resourceUri, new { last_knowledge_of_server = lastKnowledgeOfServer }, _bearerToken, cancellationToken);
}