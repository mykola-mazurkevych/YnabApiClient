using mmazur.YnabApiClient.Infrastructure;
using mmazur.YnabApiClient.V1.Interfaces.Payees;
using mmazur.YnabApiClient.V1.Models.Payees;

namespace mmazur.YnabApiClient.V1.Clients.Payees;

internal sealed class YnabV1PayeeApiClient(IHttpClientFactory httpClientFactory, Uri baseUri, Guid payeeId, string bearerToken)
    : YnabApiClientBase(httpClientFactory), IYnabV1PayeeApiClient
{
    private readonly Uri _resourceUri = new(baseUri, $"{payeeId}/");

    public Task<PayeeResponse> GetAsync(CancellationToken cancellationToken = default) =>
        this.GetAsync<PayeeResponse>(_resourceUri, null, bearerToken, cancellationToken);

    public Task<PayeeResponse> UpdateAsync(UpdatePayee payee, CancellationToken cancellationToken = default) =>
        this.PatchAsync<PayeeResponse>(_resourceUri, new UpdatePayeeRequest { Payee = payee }, bearerToken, cancellationToken);
}