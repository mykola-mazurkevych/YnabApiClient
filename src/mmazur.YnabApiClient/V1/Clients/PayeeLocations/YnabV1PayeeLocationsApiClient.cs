using mmazur.YnabApiClient.Extensions;
using mmazur.YnabApiClient.Infrastructure;
using mmazur.YnabApiClient.V1.Interfaces.PayeeLocations;
using mmazur.YnabApiClient.V1.Models.PayeeLocations;

namespace mmazur.YnabApiClient.V1.Clients.PayeeLocations;

internal sealed class YnabV1PayeeLocationsApiClient(IHttpClientFactory httpClientFactory, Uri baseUri, string bearerToken)
    : YnabApiClientBase(httpClientFactory), IYnabV1PayeeLocationsApiClient
{
    private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
    private readonly Uri _resourcesUri = new(baseUri, "payee_locations/");
    private readonly Dictionary<Guid, IYnabV1PayeeLocationApiClient> _payeeLocationClients = new();

    public IYnabV1PayeeLocationApiClient this[Guid payeeLocationId] =>
        _payeeLocationClients.GetOrAdd(payeeLocationId, () => new YnabV1PayeeLocationApiClient(_httpClientFactory, _resourcesUri, payeeLocationId, bearerToken));

    public Task<PayeeLocationsResponse> GetAsync(CancellationToken cancellationToken = default) =>
        this.GetAsync<PayeeLocationsResponse>(_resourcesUri, null, bearerToken, cancellationToken);
}