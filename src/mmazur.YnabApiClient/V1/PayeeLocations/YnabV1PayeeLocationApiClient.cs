using Microsoft.Extensions.Logging;

using mmazur.YnabApiClient.Extensions;
using mmazur.YnabApiClient.V1.Common;
using mmazur.YnabApiClient.V1.PayeeLocations.Models;

namespace mmazur.YnabApiClient.V1.PayeeLocations;

internal sealed class YnabV1PayeeLocationApiClient(HttpClient httpClient, Uri parentUri, Guid payeeLocationId, ILogger? logger) :
    YnabApiClientBase(httpClient, logger),
    IYnabV1PayeeLocationApiClient
{
    private readonly Uri _resourceUri = parentUri.AppendPath($"{payeeLocationId}/");

    public Task<PayeeLocationResponse?> GetAsync(CancellationToken cancellationToken = default) =>
        GetAsync<PayeeLocationResponse>(_resourceUri, cancellationToken);
}