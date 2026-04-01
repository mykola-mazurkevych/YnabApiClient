using Microsoft.Extensions.Logging;

using mmazur.YnabApiClient.Extensions;
using mmazur.YnabApiClient.V1.Categories;
using mmazur.YnabApiClient.V1.Common;
using mmazur.YnabApiClient.V1.Months.Models;
using mmazur.YnabApiClient.V1.Transactions;

namespace mmazur.YnabApiClient.V1.Months;

internal sealed class YnabV1MonthApiClient(HttpClient httpClient, Uri parentUri, DateOnly month, ILogger? logger) :
    YnabApiClientBase(httpClient, logger),
    IYnabV1MonthApiClient
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly ILogger? _logger = logger;
    private readonly Uri _resourceUri = parentUri.AppendPath($"{month}/");

    public IYnabV1MonthCategoriesApiClient Categories =>
        new YnabV1CategoriesApiClient(_httpClient, _resourceUri, _logger);

    public IYnabV1TransactionsGetApiClient Transactions =>
        new YnabV1TransactionsApiClient(_httpClient, _resourceUri, _logger);

    public Task<MonthDetailResponse?> GetAsync(CancellationToken cancellationToken = default) =>
        GetAsync<MonthDetailResponse>(_resourceUri, cancellationToken);
}