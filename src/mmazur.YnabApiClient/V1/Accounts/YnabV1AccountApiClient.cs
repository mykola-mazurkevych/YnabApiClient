using Microsoft.Extensions.Logging;

using mmazur.YnabApiClient.Extensions;
using mmazur.YnabApiClient.V1.Accounts.Models;
using mmazur.YnabApiClient.V1.Common;
using mmazur.YnabApiClient.V1.Transactions;

namespace mmazur.YnabApiClient.V1.Accounts;

internal sealed class YnabV1AccountApiClient(HttpClient httpClient, Uri parentUri, Guid accountId, ILogger? logger) :
    YnabApiClientBase(httpClient, logger),
    IYnabV1AccountApiClient
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly ILogger? _logger = logger;
    private readonly Uri _resourceUri = parentUri.AppendPath($"{accountId}/");

    public IYnabV1TransactionsGetApiClient Transactions =>
        new YnabV1TransactionsApiClient(_httpClient, _resourceUri, _logger);

    public Task<AccountResponse?> GetAsync(CancellationToken cancellationToken = default) =>
        GetAsync<AccountResponse>(_resourceUri, cancellationToken);
}