using Microsoft.Extensions.Logging;

using mmazur.YnabApiClient.V1.Categories.Models;
using mmazur.YnabApiClient.V1.Common;
using mmazur.YnabApiClient.V1.Transactions;

namespace mmazur.YnabApiClient.V1.Categories;

internal sealed class YnabV1CategoryApiClient(IHttpClientFactory httpClientFactory, ILogger? logger, Uri baseUri, Guid categoryId, string bearerToken) :
    YnabApiClientBase(httpClientFactory, logger),
    IYnabV1CategoryApiClient,
    IYnabV1MonthCategoryApiClient
{
    private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
    private readonly ILogger? _logger = logger;
    private readonly Uri _resourceUri = new(baseUri, $"{categoryId}/");

    public IYnabV1TransactionsGetApiClient Transactions =>
        new YnabV1TransactionsApiClient(_httpClientFactory, _logger, _resourceUri, bearerToken);

    public Task<CategoryResponse?> GetAsync(CancellationToken cancellationToken = default) =>
        this.GetAsync<CategoryResponse>(_resourceUri, bearerToken, cancellationToken);

    public Task<SaveCategoryResponse> UpdateAsync(SaveCategory category, CancellationToken cancellationToken = default) =>
        this.PatchAsync<SaveCategoryResponse>(_resourceUri, new PatchCategoryWrapper { Category = category }, bearerToken, cancellationToken);

    public Task<SaveCategoryResponse> UpdateAsync(SaveMonthCategory category, CancellationToken cancellationToken = default) =>
        this.PatchAsync<SaveCategoryResponse>(_resourceUri, new PatchMonthCategoryWrapper { Category = category }, bearerToken, cancellationToken);
}