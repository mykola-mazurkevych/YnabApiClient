using Microsoft.Extensions.Logging;

using mmazur.YnabApiClient.Extensions;
using mmazur.YnabApiClient.Infrastructure;
using mmazur.YnabApiClient.V1.Interfaces.Payees;
using mmazur.YnabApiClient.V1.Models.Payees;

namespace mmazur.YnabApiClient.V1.Clients.Payees;

internal sealed class YnabV1PayeesApiClient(IHttpClientFactory httpClientFactory, ILogger? logger, Uri baseUri, string bearerToken)
    : YnabApiClientBase(httpClientFactory, logger), IYnabV1PayeesApiClient
{
    private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
    private readonly ILogger? _logger = logger;
    private readonly Uri _resourcesUri = new(baseUri, "payees/");
    private readonly Dictionary<Guid, IYnabV1PayeeApiClient> _payeeClients = [];

    public IYnabV1PayeeApiClient this[Guid payeeId] =>
        _payeeClients.GetOrAdd(payeeId, () => new YnabV1PayeeApiClient(_httpClientFactory, _logger, _resourcesUri, payeeId, bearerToken));

    public Task<PayeesResponse?> GetAsync(CancellationToken cancellationToken = default) =>
        this.GetAsync<PayeesResponse>(_resourcesUri, bearerToken, cancellationToken);

    public Task<PayeesResponse?> GetAsync(long lastKnowledgeOfServer, CancellationToken cancellationToken = default) =>
        this.GetAsync<PayeesResponse>(_resourcesUri, new { last_knowledge_of_server = lastKnowledgeOfServer }, bearerToken, cancellationToken);
}