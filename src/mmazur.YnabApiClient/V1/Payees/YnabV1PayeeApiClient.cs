using Microsoft.Extensions.Logging;

using mmazur.YnabApiClient.Extensions;
using mmazur.YnabApiClient.V1.Common;
using mmazur.YnabApiClient.V1.PayeeLocations;
using mmazur.YnabApiClient.V1.Payees.Models;
using mmazur.YnabApiClient.V1.Transactions;

namespace mmazur.YnabApiClient.V1.Payees;

internal sealed class YnabV1PayeeApiClient(HttpClient httpClient, Uri parentUri, Guid payeeId, ILogger? logger) :
    YnabApiClientBase(httpClient, logger),
    IYnabV1PayeeApiClient
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly ILogger? _logger = logger;
    private readonly Uri _resourceUri = parentUri.AppendPath($"{payeeId}/");

    public IYnabV1PayeeLocationsGetApiClient Locations =>
        new YnabV1PayeeLocationsApiClient(_httpClient, _resourceUri, _logger);

    public IYnabV1TransactionsGetApiClient Transactions =>
        new YnabV1TransactionsApiClient(_httpClient, _resourceUri, _logger);

    public Task<PayeeResponse?> GetAsync(CancellationToken cancellationToken = default) =>
        GetAsync<PayeeResponse>(_resourceUri, cancellationToken);

    public Task<SavePayeeResponse> UpdateAsync(SavePayee payee, CancellationToken cancellationToken = default) =>
        PatchAsync<SavePayeeResponse>(_resourceUri, new PatchPayeeWrapper { Payee = payee }, cancellationToken);
}