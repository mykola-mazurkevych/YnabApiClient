using mmazur.YnabApiClient.Infrastructure;
using mmazur.YnabApiClient.V1.Interfaces.PayeeLocations;
using mmazur.YnabApiClient.V1.Models.PayeeLocations;

namespace mmazur.YnabApiClient.V1.Clients.PayeeLocations;

internal sealed class YnabV1PayeeLocationApiClient(IHttpClientFactory httpClientFactory, Uri baseUri, Guid payeeLocationId, string bearerToken)
    : YnabApiClientBase(httpClientFactory), IYnabV1PayeeLocationApiClient
{
    private readonly Uri _resourceUri = new(baseUri, $"{payeeLocationId}/");

    public Task<PayeeLocationResponse> GetAsync(CancellationToken cancellationToken = default) =>
        this.GetAsync<PayeeLocationResponse>(_resourceUri, null, bearerToken, cancellationToken);
}