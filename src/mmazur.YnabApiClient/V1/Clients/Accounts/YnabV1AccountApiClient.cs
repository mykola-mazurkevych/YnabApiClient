using Microsoft.Extensions.Logging;

using mmazur.YnabApiClient.Infrastructure;
using mmazur.YnabApiClient.V1.Clients.Transactions;
using mmazur.YnabApiClient.V1.Interfaces.Accounts;
using mmazur.YnabApiClient.V1.Interfaces.Transactions;
using mmazur.YnabApiClient.V1.Models.Accounts;

namespace mmazur.YnabApiClient.V1.Clients.Accounts;

internal sealed class YnabV1AccountApiClient(IHttpClientFactory httpClientFactory, ILogger? logger, Uri baseUri, Guid accountId, string bearerToken)
    : YnabApiClientBase(httpClientFactory, logger), IYnabV1AccountApiClient
{
    private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
    private readonly ILogger? _logger = logger;
    private readonly Uri _resourceUri = new(baseUri, $"{accountId}/");

    public IYnabV1TransactionsApiClient Transactions =>
        new YnabV1TransactionsApiClient(_httpClientFactory, _logger, baseUri, bearerToken);

    public Task<AccountResponse?> GetAsync(CancellationToken cancellationToken = default) =>
        this.GetAsync<AccountResponse>(_resourceUri, bearerToken, cancellationToken);
}