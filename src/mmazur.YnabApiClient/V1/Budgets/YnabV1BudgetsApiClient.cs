using Microsoft.Extensions.Logging;

using mmazur.YnabApiClient.Extensions;
using mmazur.YnabApiClient.V1.Budgets.Models;
using mmazur.YnabApiClient.V1.Common;

namespace mmazur.YnabApiClient.V1.Budgets;

internal sealed class YnabV1BudgetsApiClient(HttpClient httpClient, Uri parentUri, ILogger? logger) :
    YnabApiClientBase(httpClient, logger),
    IYnabV1BudgetsApiClient
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly ILogger? _logger = logger;
    private readonly Uri _resourcesUri = parentUri.AppendPath("budgets/");

    public IYnabV1BudgetApiClient this[Guid budgetId] =>
        new YnabV1BudgetApiClient(_httpClient, _resourcesUri, budgetId, _logger);

    public IYnabV1BudgetApiClient Default =>
        GetBudgetApiClient(BudgetType.Default);

    public IYnabV1BudgetApiClient LastUsed =>
        GetBudgetApiClient(BudgetType.LastUsed);

    public Task<BudgetSummaryResponse?> GetAsync(CancellationToken cancellationToken = default) =>
        GetAsync<BudgetSummaryResponse>(_resourcesUri, cancellationToken);

    public Task<BudgetSummaryResponse?> GetAsync(bool includeAccounts, CancellationToken cancellationToken = default) =>
        GetAsync<BudgetSummaryResponse>(_resourcesUri, new { include_accounts = includeAccounts }, cancellationToken);

    private YnabV1BudgetApiClient GetBudgetApiClient(BudgetType budgetType) =>
        new(_httpClient, _resourcesUri, budgetType, _logger);
}