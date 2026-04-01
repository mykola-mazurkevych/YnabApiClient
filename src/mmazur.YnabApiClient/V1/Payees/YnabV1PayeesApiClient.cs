using Microsoft.Extensions.Logging;

using mmazur.YnabApiClient.Extensions;
using mmazur.YnabApiClient.V1.Common;
using mmazur.YnabApiClient.V1.Payees.Models;

namespace mmazur.YnabApiClient.V1.Payees;

internal sealed class YnabV1PayeesApiClient(HttpClient httpClient, Uri parentUri, ILogger? logger) :
    YnabApiClientBase(httpClient, logger),
    IYnabV1PayeesApiClient
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly ILogger? _logger = logger;
    private readonly Uri _resourcesUri = parentUri.AppendPath("payees/");

    public IYnabV1PayeeApiClient this[Guid payeeId] =>
        new YnabV1PayeeApiClient(_httpClient, _resourcesUri, payeeId, _logger);

    public Task<PayeesResponse?> GetAsync(CancellationToken cancellationToken = default) =>
        GetAsync<PayeesResponse>(_resourcesUri, cancellationToken);

    public Task<PayeesResponse?> GetAsync(long lastKnowledgeOfServer, CancellationToken cancellationToken = default) =>
        GetAsync<PayeesResponse>(_resourcesUri, new { last_knowledge_of_server = lastKnowledgeOfServer }, cancellationToken);
}