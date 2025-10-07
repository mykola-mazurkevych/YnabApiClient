using Microsoft.Extensions.Logging;

using mmazur.YnabApiClient.V1.Common;
using mmazur.YnabApiClient.V1.PayeeLocations.Models;

namespace mmazur.YnabApiClient.V1.PayeeLocations;

internal sealed class YnabV1PayeeLocationApiClient(IHttpClientFactory httpClientFactory, ILogger? logger, Uri baseUri, Guid payeeLocationId, string bearerToken)
    : YnabApiClientBase(httpClientFactory, logger), IYnabV1PayeeLocationApiClient
{
    private readonly Uri _resourceUri = new(baseUri, $"{payeeLocationId}/");

    public Task<PayeeLocationResponse?> GetAsync(CancellationToken cancellationToken = default) =>
        this.GetAsync<PayeeLocationResponse>(_resourceUri, bearerToken, cancellationToken);
}