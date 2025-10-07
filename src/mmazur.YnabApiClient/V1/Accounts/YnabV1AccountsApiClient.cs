using Microsoft.Extensions.Logging;

using mmazur.YnabApiClient.V1.Accounts.Models;
using mmazur.YnabApiClient.V1.Common;

namespace mmazur.YnabApiClient.V1.Accounts;

internal sealed class YnabV1AccountsApiClient(IHttpClientFactory httpClientFactory, ILogger? logger, Uri baseUri, string bearerToken)
    : YnabApiClientBase(httpClientFactory, logger), IYnabV1AccountsApiClient
{
    private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
    private readonly ILogger? _logger = logger;
    private readonly Uri _resourcesUri = new(baseUri, "accounts/");

    public IYnabV1AccountApiClient this[Guid accountId] =>
        new YnabV1AccountApiClient(_httpClientFactory, _logger, _resourcesUri, accountId, bearerToken);

    public Task<AccountsResponse?> GetAsync(CancellationToken cancellationToken = default) =>
        this.GetAsync<AccountsResponse>(_resourcesUri, bearerToken, cancellationToken);

    public Task<AccountsResponse?> GetAsync(long lastKnowledgeOfServer, CancellationToken cancellationToken = default) =>
        this.GetAsync<AccountsResponse>(_resourcesUri, new { last_knowledge_of_server = lastKnowledgeOfServer }, bearerToken, cancellationToken);

    public Task<AccountResponse> CreateAsync(SaveAccount account, CancellationToken cancellationToken = default) =>
        this.PostAsync<AccountResponse>(_resourcesUri, new PostAccountWrapper { Account = account }, bearerToken, cancellationToken);
}