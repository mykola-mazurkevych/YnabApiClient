using Microsoft.Extensions.Logging;

using mmazur.YnabApiClient.Extensions;
using mmazur.YnabApiClient.V1.Common;
using mmazur.YnabApiClient.V1.Months.Models;

namespace mmazur.YnabApiClient.V1.Months;

internal sealed class YnabV1MonthsApiClient(HttpClient httpClient, Uri parentUri, ILogger? logger) :
    YnabApiClientBase(httpClient, logger),
    IYnabV1MonthsApiClient
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly ILogger? _logger = logger;
    private readonly Uri _resourcesUri = parentUri.AppendPath("months/");

    public IYnabV1MonthApiClient this[DateOnly month] =>
        new YnabV1MonthApiClient(_httpClient, _resourcesUri, month, _logger);

    public Task<MonthSummariesResponse?> GetAsync(CancellationToken cancellationToken = default) =>
        GetAsync<MonthSummariesResponse>(_resourcesUri, cancellationToken);

    public Task<MonthSummariesResponse?> GetAsync(long lastKnowledgeOfServer, CancellationToken cancellationToken = default) =>
        GetAsync<MonthSummariesResponse>(_resourcesUri, new { last_knowledge_of_server = lastKnowledgeOfServer }, cancellationToken);
}