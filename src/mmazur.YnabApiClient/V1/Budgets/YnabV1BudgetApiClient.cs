using Microsoft.Extensions.Logging;

using mmazur.YnabApiClient.Extensions;
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
    private readonly HttpClient _httpClient;
    private readonly ILogger? _logger;
    private readonly Uri _resourceUri;

    public YnabV1BudgetApiClient(HttpClient httpClient, Uri parentUri, Guid budgetId, ILogger? logger) :
        base(httpClient, logger)
    {
        _httpClient = httpClient;
        _logger = logger;
        _resourceUri = parentUri.AppendPath($"{budgetId}/");
    }

    public YnabV1BudgetApiClient(HttpClient httpClient, Uri parentUri, BudgetType budgetType, ILogger? logger) :
        base(httpClient, logger)
    {
        _httpClient = httpClient;
        _logger = logger;
        _resourceUri = parentUri.AppendPath($"{budgetType.ToCustomString()}/");
    }

    public IYnabV1BudgetSettingsApiClient Settings =>
        new YnabV1BudgetSettingsApiClient(_httpClient, _resourceUri, _logger);

    public IYnabV1AccountsApiClient Accounts =>
        new YnabV1AccountsApiClient(_httpClient, _resourceUri, _logger);

    public IYnabV1CategoriesApiClient Categories =>
        new YnabV1CategoriesApiClient(_httpClient, _resourceUri, _logger);

    public IYnabV1MonthsApiClient Months =>
        new YnabV1MonthsApiClient(_httpClient, _resourceUri, _logger);

    public IYnabV1PayeesApiClient Payees =>
        new YnabV1PayeesApiClient(_httpClient, _resourceUri, _logger);

    public IYnabV1PayeeLocationsApiClient PayeeLocations =>
        new YnabV1PayeeLocationsApiClient(_httpClient, _resourceUri, _logger);

    public IYnabV1ScheduledTransactionsApiClient ScheduledTransactions =>
        new YnabV1ScheduledTransactionsApiClient(_httpClient, _resourceUri, _logger);

    public IYnabV1TransactionsApiClient Transactions =>
        new YnabV1TransactionsApiClient(_httpClient, _resourceUri, _logger);

    public Task<BudgetDetailResponse?> GetAsync(CancellationToken cancellationToken = default) =>
        GetAsync<BudgetDetailResponse>(_resourceUri, cancellationToken);

    public Task<BudgetDetailResponse?> GetAsync(long lastKnowledgeOfServer, CancellationToken cancellationToken = default) =>
        GetAsync<BudgetDetailResponse>(_resourceUri, new { last_knowledge_of_server = lastKnowledgeOfServer }, cancellationToken);
}