using mmazur.YnabApiClient.Extensions;
using mmazur.YnabApiClient.Infrastructure;
using mmazur.YnabApiClient.V1.Interfaces.Months;
using mmazur.YnabApiClient.V1.Models.Months;

namespace mmazur.YnabApiClient.V1.Clients.Months;

internal sealed class YnabV1MonthsApiClient(IHttpClientFactory httpClientFactory, Uri baseUri, string bearerToken)
    : YnabApiClientBase(httpClientFactory), IYnabV1MonthsApiClient
{
    private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
    private readonly Uri _resourcesUri = new(baseUri, "months/");
    private readonly Dictionary<DateOnly, IYnabV1MonthApiClient> _monthClients = [];

    public IYnabV1MonthApiClient this[DateOnly month] =>
        _monthClients.GetOrAdd(month, () => new YnabV1MonthApiClient(_httpClientFactory, _resourcesUri, month, bearerToken));

    public Task<MonthsResponse> GetAsync(CancellationToken cancellationToken = default) =>
        this.GetAsync<MonthsResponse>(_resourcesUri, null, bearerToken, cancellationToken);

    public Task<MonthsResponse> GetAsync(long lastKnowledgeOfServer, CancellationToken cancellationToken = default) =>
        this.GetAsync<MonthsResponse>(_resourcesUri, new { last_knowledge_of_server = lastKnowledgeOfServer }, bearerToken, cancellationToken);
}