using Microsoft.Extensions.Logging;

using mmazur.YnabApiClient.V1.Common;
using mmazur.YnabApiClient.V1.Months.Models;

namespace mmazur.YnabApiClient.V1.Months;

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