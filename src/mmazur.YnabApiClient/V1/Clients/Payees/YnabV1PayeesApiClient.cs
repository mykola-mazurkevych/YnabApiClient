using mmazur.YnabApiClient.Extensions;
using mmazur.YnabApiClient.Infrastructure;
using mmazur.YnabApiClient.V1.Interfaces.Payees;
using mmazur.YnabApiClient.V1.Models.Payees;

namespace mmazur.YnabApiClient.V1.Clients.Payees;

internal sealed class YnabV1PayeesApiClient(IHttpClientFactory httpClientFactory, Uri baseUri, string bearerToken)
    : YnabApiClientBase(httpClientFactory), IYnabV1PayeesApiClient
{
    private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
    private readonly Uri _resourcesUri = new(baseUri, "payees/");
    private readonly Dictionary<Guid, IYnabV1PayeeApiClient> _payeeClients = [];

    public IYnabV1PayeeApiClient this[Guid payeeId] =>
        _payeeClients.GetOrAdd(payeeId, () => new YnabV1PayeeApiClient(_httpClientFactory, _resourcesUri, payeeId, bearerToken));

    public Task<PayeesResponse> GetAsync(CancellationToken cancellationToken = default) =>
        this.GetAsync<PayeesResponse>(_resourcesUri, null, bearerToken, cancellationToken);

    public Task<PayeesResponse> GetAsync(long lastKnowledgeOfServer, CancellationToken cancellationToken = default) =>
        this.GetAsync<PayeesResponse>(_resourcesUri, new { last_knowledge_of_server = lastKnowledgeOfServer }, bearerToken, cancellationToken);
}