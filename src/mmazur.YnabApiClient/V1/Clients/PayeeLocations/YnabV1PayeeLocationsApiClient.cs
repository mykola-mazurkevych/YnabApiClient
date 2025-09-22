using Microsoft.Extensions.Logging;

using mmazur.YnabApiClient.Infrastructure;
using mmazur.YnabApiClient.V1.Interfaces.PayeeLocations;
using mmazur.YnabApiClient.V1.Models.PayeeLocations;

namespace mmazur.YnabApiClient.V1.Clients.PayeeLocations;

internal sealed class YnabV1PayeeLocationsApiClient(IHttpClientFactory httpClientFactory, ILogger? logger, Uri baseUri, string bearerToken)
    : YnabApiClientBase(httpClientFactory, logger), IYnabV1PayeeLocationsApiClient
{
    private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
    private readonly ILogger? _logger = logger;
    private readonly Uri _resourcesUri = new(baseUri, "payee_locations/");

    public IYnabV1PayeeLocationApiClient this[Guid payeeLocationId] =>
        new YnabV1PayeeLocationApiClient(_httpClientFactory, _logger, _resourcesUri, payeeLocationId, bearerToken);

    public Task<PayeeLocationsResponse?> GetAsync(CancellationToken cancellationToken = default) =>
        this.GetAsync<PayeeLocationsResponse>(_resourcesUri, bearerToken, cancellationToken);
}