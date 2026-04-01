using Microsoft.Extensions.Logging;

using mmazur.YnabApiClient.Extensions;
using mmazur.YnabApiClient.V1.Accounts.Models;
using mmazur.YnabApiClient.V1.Common;

namespace mmazur.YnabApiClient.V1.Accounts;

internal sealed class YnabV1AccountsApiClient(HttpClient httpClient, Uri parentUri, ILogger? logger) :
    YnabApiClientBase(httpClient, logger),
    IYnabV1AccountsApiClient
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly ILogger? _logger = logger;
    private readonly Uri _resourcesUri = parentUri.AppendPath("accounts/");

    public IYnabV1AccountApiClient this[Guid accountId] =>
        new YnabV1AccountApiClient(_httpClient, _resourcesUri, accountId, _logger);

    public Task<AccountsResponse?> GetAsync(CancellationToken cancellationToken = default) =>
        GetAsync<AccountsResponse>(_resourcesUri, cancellationToken);

    public Task<AccountsResponse?> GetAsync(long lastKnowledgeOfServer, CancellationToken cancellationToken = default) =>
        GetAsync<AccountsResponse>(_resourcesUri, new { last_knowledge_of_server = lastKnowledgeOfServer }, cancellationToken);

    public Task<AccountResponse> CreateAsync(SaveAccount account, CancellationToken cancellationToken = default) =>
        PostAsync<AccountResponse>(_resourcesUri, new PostAccountWrapper { Account = account }, cancellationToken);
}