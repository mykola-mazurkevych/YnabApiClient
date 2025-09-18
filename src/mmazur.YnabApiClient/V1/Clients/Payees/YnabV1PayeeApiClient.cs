using Microsoft.Extensions.Logging;

using mmazur.YnabApiClient.Infrastructure;
using mmazur.YnabApiClient.V1.Clients.PayeeLocations;
using mmazur.YnabApiClient.V1.Clients.Transactions;
using mmazur.YnabApiClient.V1.Interfaces.PayeeLocations;
using mmazur.YnabApiClient.V1.Interfaces.Payees;
using mmazur.YnabApiClient.V1.Interfaces.Transactions;
using mmazur.YnabApiClient.V1.Models.Payees;

namespace mmazur.YnabApiClient.V1.Clients.Payees;

internal sealed class YnabV1PayeeApiClient(IHttpClientFactory httpClientFactory, ILogger? logger, Uri baseUri, Guid payeeId, string bearerToken)
    : YnabApiClientBase(httpClientFactory, logger), IYnabV1PayeeApiClient
{
    private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
    private readonly ILogger? _logger = logger;
    private readonly Uri _resourceUri = new(baseUri, $"{payeeId}/");

    public IYnabV1PayeeLocationsApiClient Locations => new YnabV1PayeeLocationsApiClient(_httpClientFactory, _logger, _resourceUri, bearerToken);

    public IYnabV1TransactionsApiClient Transactions => new YnabV1TransactionsApiClient(_httpClientFactory, _logger, _resourceUri, bearerToken);

    public Task<PayeeResponse?> GetAsync(CancellationToken cancellationToken = default) =>
        this.GetAsync<PayeeResponse>(_resourceUri, bearerToken, cancellationToken);

    public Task<SavePayeeResponse> UpdateAsync(SavePayee payee, CancellationToken cancellationToken = default) =>
        this.PatchAsync<SavePayeeResponse>(_resourceUri, new PatchPayeeWrapper { Payee = payee }, bearerToken, cancellationToken);
}