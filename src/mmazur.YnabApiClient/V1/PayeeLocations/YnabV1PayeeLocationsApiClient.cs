using Microsoft.Extensions.Logging;

using mmazur.YnabApiClient.Extensions;
using mmazur.YnabApiClient.V1.Common;
using mmazur.YnabApiClient.V1.PayeeLocations.Models;
using mmazur.YnabApiClient.V1.Payees;

namespace mmazur.YnabApiClient.V1.PayeeLocations;

internal sealed class YnabV1PayeeLocationsApiClient(HttpClient httpClient, Uri parentUri, ILogger? logger) :
    YnabApiClientBase(httpClient, logger),
    IYnabV1PayeeLocationsApiClient,
    IYnabV1PayeeLocationsGetApiClient
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly ILogger? _logger = logger;
    private readonly Uri _resourcesUri = parentUri.AppendPath("payee_locations/");

    public IYnabV1PayeeLocationApiClient this[Guid payeeLocationId] =>
        new YnabV1PayeeLocationApiClient(_httpClient, _resourcesUri, payeeLocationId, _logger);

    public Task<PayeeLocationsResponse?> GetAsync(CancellationToken cancellationToken = default) =>
        GetAsync<PayeeLocationsResponse>(_resourcesUri, cancellationToken);
}