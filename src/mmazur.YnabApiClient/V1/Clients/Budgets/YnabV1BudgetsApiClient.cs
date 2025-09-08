using mmazur.YnabApiClient.Extensions;
using mmazur.YnabApiClient.Infrastructure;
using mmazur.YnabApiClient.V1.Interfaces.Budgets;
using mmazur.YnabApiClient.V1.Models.Budgets;

namespace mmazur.YnabApiClient.V1.Clients.Budgets;

internal sealed class YnabV1BudgetsApiClient(IHttpClientFactory httpClientFactory, Uri baseUri, string bearerToken)
    : YnabApiClientBase(httpClientFactory), IYnabV1BudgetsApiClient
{
    private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
    private readonly Uri _resourcesUri = new(baseUri, "budgets/");
    private readonly Dictionary<string, IYnabV1BudgetApiClient> _budgetClients = [];

    public IYnabV1BudgetApiClient this[Guid budgetId] =>
        _budgetClients.GetOrAdd(budgetId.ToString(), () => new YnabV1BudgetApiClient(_httpClientFactory, _resourcesUri, budgetId, bearerToken));

    public IYnabV1BudgetApiClient Default =>
        this.GetBudgetApiClient(BudgetType.Default);

    public IYnabV1BudgetApiClient LastUsed =>
        this.GetBudgetApiClient(BudgetType.LastUsed);

    public Task<BudgetSummaryResponse> GetAsync(bool includeAccounts, CancellationToken cancellationToken = default) =>
        this.GetAsync<BudgetSummaryResponse>(_resourcesUri, new { include_accounts = includeAccounts }, bearerToken, cancellationToken);

    private IYnabV1BudgetApiClient GetBudgetApiClient(BudgetType budgetType) =>
        _budgetClients.GetOrAdd(budgetType.ToCustomString(), () => new YnabV1BudgetApiClient(_httpClientFactory, _resourcesUri, budgetType, bearerToken));
}