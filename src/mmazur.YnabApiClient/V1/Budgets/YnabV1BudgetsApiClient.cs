using Microsoft.Extensions.Logging;

using mmazur.YnabApiClient.V1.Budgets.Models;
using mmazur.YnabApiClient.V1.Common;

namespace mmazur.YnabApiClient.V1.Budgets;

internal sealed class YnabV1BudgetsApiClient(IHttpClientFactory httpClientFactory, ILogger? logger, Uri baseUri, string bearerToken)
    : YnabApiClientBase(httpClientFactory, logger), IYnabV1BudgetsApiClient
{
    private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
    private readonly ILogger? _logger = logger;
    private readonly Uri _resourcesUri = new(baseUri, "budgets/");

    public IYnabV1BudgetApiClient this[Guid budgetId] =>
        new YnabV1BudgetApiClient(_httpClientFactory, _logger, _resourcesUri, budgetId, bearerToken);

    public IYnabV1BudgetApiClient Default =>
        this.GetBudgetApiClient(BudgetType.Default);

    public IYnabV1BudgetApiClient LastUsed =>
        this.GetBudgetApiClient(BudgetType.LastUsed);

    public Task<BudgetSummaryResponse?> GetAsync(CancellationToken cancellationToken = default) =>
        this.GetAsync<BudgetSummaryResponse>(_resourcesUri, bearerToken, cancellationToken);

    public Task<BudgetSummaryResponse?> GetAsync(bool includeAccounts, CancellationToken cancellationToken = default) =>
        this.GetAsync<BudgetSummaryResponse>(_resourcesUri, new { include_accounts = includeAccounts }, bearerToken, cancellationToken);

    private YnabV1BudgetApiClient GetBudgetApiClient(BudgetType budgetType) =>
        new (_httpClientFactory, _logger, _resourcesUri, budgetType, bearerToken);
}