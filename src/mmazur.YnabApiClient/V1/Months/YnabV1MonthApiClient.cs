using Microsoft.Extensions.Logging;

using mmazur.YnabApiClient.V1.Categories;
using mmazur.YnabApiClient.V1.Common;
using mmazur.YnabApiClient.V1.Months.Models;
using mmazur.YnabApiClient.V1.Transactions;

namespace mmazur.YnabApiClient.V1.Months;

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