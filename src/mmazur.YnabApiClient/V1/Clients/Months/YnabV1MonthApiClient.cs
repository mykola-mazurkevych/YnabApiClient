using Microsoft.Extensions.Logging;

using mmazur.YnabApiClient.Infrastructure;
using mmazur.YnabApiClient.V1.Clients.Categories;
using mmazur.YnabApiClient.V1.Clients.Transactions;
using mmazur.YnabApiClient.V1.Interfaces.Categories;
using mmazur.YnabApiClient.V1.Interfaces.Months;
using mmazur.YnabApiClient.V1.Interfaces.Transactions;
using mmazur.YnabApiClient.V1.Models.Months;

namespace mmazur.YnabApiClient.V1.Clients.Months;

internal sealed class YnabV1MonthApiClient(IHttpClientFactory httpClientFactory, ILogger? logger, Uri baseUri, DateOnly month, string bearerToken)
    : YnabApiClientBase(httpClientFactory, logger), IYnabV1MonthApiClient
{
    private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
    private readonly ILogger? _logger = logger;
    private readonly Uri _resourceUri = new(baseUri, $"{month}/");

    public IYnabV1CategoriesApiClient Categories => new YnabV1CategoriesApiClient(_httpClientFactory, _logger, _resourceUri, bearerToken);

    public IYnabV1TransactionsApiClient Transactions => new YnabV1TransactionsApiClient(_httpClientFactory, _logger, _resourceUri, bearerToken);

    public Task<MonthDetailResponse?> GetAsync(CancellationToken cancellationToken = default) =>
        this.GetAsync<MonthDetailResponse>(_resourceUri, bearerToken, cancellationToken);
}