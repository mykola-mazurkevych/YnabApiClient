using mmazur.YnabApiClient.Infrastructure;
using mmazur.YnabApiClient.V1.Clients.PayeeLocations;
using mmazur.YnabApiClient.V1.Interfaces.PayeeLocations;
using mmazur.YnabApiClient.V1.Interfaces.Payees;
using mmazur.YnabApiClient.V1.Models.Payees;

namespace mmazur.YnabApiClient.V1.Clients.Payees;

internal sealed class YnabV1PayeeApiClient(IHttpClientFactory httpClientFactory, Uri baseUri, Guid payeeId, string bearerToken)
    : YnabApiClientBase(httpClientFactory), IYnabV1PayeeApiClient
{
    private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
    private readonly Uri _resourceUri = new(baseUri, $"{payeeId}/");

    public IYnabV1PayeeLocationsApiClient Locations => new YnabV1PayeeLocationsApiClient(_httpClientFactory, _resourceUri, bearerToken);

    public Task<PayeeResponse> GetAsync(CancellationToken cancellationToken = default) =>
        this.GetAsync<PayeeResponse>(_resourceUri, null, bearerToken, cancellationToken);

    public Task<PayeeResponse> UpdateAsync(UpdatePayee payee, CancellationToken cancellationToken = default) =>
        this.PatchAsync<PayeeResponse>(_resourceUri, new UpdatePayeeRequest { Payee = payee }, bearerToken, cancellationToken);
}