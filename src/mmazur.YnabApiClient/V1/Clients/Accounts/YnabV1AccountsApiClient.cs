using Microsoft.Extensions.Logging;

using mmazur.YnabApiClient.Extensions;
using mmazur.YnabApiClient.Infrastructure;
using mmazur.YnabApiClient.V1.Interfaces.Accounts;
using mmazur.YnabApiClient.V1.Models.Accounts;

namespace mmazur.YnabApiClient.V1.Clients.Accounts;

internal sealed class YnabV1AccountsApiClient(IHttpClientFactory httpClientFactory, ILogger? logger, Uri baseUri, string bearerToken)
    : YnabApiClientBase(httpClientFactory, logger), IYnabV1AccountsApiClient
{
    private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
    private readonly ILogger? _logger = logger;
    private readonly Uri _resourcesUri = new(baseUri, "accounts/");
    private readonly Dictionary<Guid, IYnabV1AccountApiClient> _accountClients = [];

    public IYnabV1AccountApiClient this[Guid accountId] =>
        _accountClients.GetOrAdd(accountId, () => new YnabV1AccountApiClient(_httpClientFactory, _logger, _resourcesUri, accountId, bearerToken));

    public Task<AccountsResponse?> GetAsync(CancellationToken cancellationToken = default) =>
        this.GetAsync<AccountsResponse>(_resourcesUri, bearerToken, cancellationToken);

    public Task<AccountsResponse?> GetAsync(long lastKnowledgeOfServer, CancellationToken cancellationToken = default) =>
        this.GetAsync<AccountsResponse>(_resourcesUri, new { last_knowledge_of_server = lastKnowledgeOfServer }, bearerToken, cancellationToken);

    public Task<AccountResponse> CreateAsync(SaveAccount account, CancellationToken cancellationToken = default) =>
        this.PostAsync<AccountResponse>(_resourcesUri, new PostAccountWrapper { Account = account }, bearerToken, cancellationToken);
}