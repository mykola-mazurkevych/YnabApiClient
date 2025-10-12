using Microsoft.Extensions.Logging;

using mmazur.YnabApiClient.V1.Accounts.Models;
using mmazur.YnabApiClient.V1.Common;
using mmazur.YnabApiClient.V1.Transactions;

namespace mmazur.YnabApiClient.V1.Accounts;

internal sealed class YnabV1AccountApiClient(IHttpClientFactory httpClientFactory, ILogger? logger, Uri baseUri, Guid accountId, string bearerToken) :
    YnabApiClientBase(httpClientFactory, logger),
    IYnabV1AccountApiClient
{
    private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
    private readonly ILogger? _logger = logger;
    private readonly Uri _resourceUri = new(baseUri, $"{accountId}/");

    public IYnabV1TransactionsGetApiClient Transactions =>
        new YnabV1TransactionsApiClient(_httpClientFactory, _logger, _resourceUri, bearerToken);

    public Task<AccountResponse?> GetAsync(CancellationToken cancellationToken = default) =>
        this.GetAsync<AccountResponse>(_resourceUri, bearerToken, cancellationToken);
}