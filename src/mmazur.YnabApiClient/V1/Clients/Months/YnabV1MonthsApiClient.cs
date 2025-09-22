using Microsoft.Extensions.Logging;

using mmazur.YnabApiClient.Infrastructure;
using mmazur.YnabApiClient.V1.Interfaces.Months;
using mmazur.YnabApiClient.V1.Models.Months;

namespace mmazur.YnabApiClient.V1.Clients.Months;

internal sealed class YnabV1MonthsApiClient(IHttpClientFactory httpClientFactory, ILogger? logger, Uri baseUri, string bearerToken)
    : YnabApiClientBase(httpClientFactory, logger), IYnabV1MonthsApiClient
{
    private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
    private readonly ILogger? _logger = logger;
    private readonly Uri _resourcesUri = new(baseUri, "months/");

    public IYnabV1MonthApiClient this[DateOnly month] =>
        new YnabV1MonthApiClient(_httpClientFactory, _logger, _resourcesUri, month, bearerToken);

    public Task<MonthSummariesResponse?> GetAsync(CancellationToken cancellationToken = default) =>
        this.GetAsync<MonthSummariesResponse>(_resourcesUri, bearerToken, cancellationToken);

    public Task<MonthSummariesResponse?> GetAsync(long lastKnowledgeOfServer, CancellationToken cancellationToken = default) =>
        this.GetAsync<MonthSummariesResponse>(_resourcesUri, new { last_knowledge_of_server = lastKnowledgeOfServer }, bearerToken, cancellationToken);
}