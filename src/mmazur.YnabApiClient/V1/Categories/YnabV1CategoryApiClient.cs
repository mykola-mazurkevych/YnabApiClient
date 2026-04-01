using Microsoft.Extensions.Logging;

using mmazur.YnabApiClient.Extensions;
using mmazur.YnabApiClient.V1.Categories.Models;
using mmazur.YnabApiClient.V1.Common;
using mmazur.YnabApiClient.V1.Transactions;

namespace mmazur.YnabApiClient.V1.Categories;

internal sealed class YnabV1CategoryApiClient(HttpClient httpClient, Uri parentUri, Guid categoryId, ILogger? logger) :
    YnabApiClientBase(httpClient, logger),
    IYnabV1CategoryApiClient,
    IYnabV1MonthCategoryApiClient
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly ILogger? _logger = logger;
    private readonly Uri _resourceUri = parentUri.AppendPath($"{categoryId}/");

    public IYnabV1TransactionsGetApiClient Transactions =>
        new YnabV1TransactionsApiClient(_httpClient, _resourceUri, _logger);

    public Task<CategoryResponse?> GetAsync(CancellationToken cancellationToken = default) =>
        GetAsync<CategoryResponse>(_resourceUri, cancellationToken);

    public Task<SaveCategoryResponse> UpdateAsync(SaveCategory category, CancellationToken cancellationToken = default) =>
        PatchAsync<SaveCategoryResponse>(_resourceUri, new PatchCategoryWrapper { Category = category }, cancellationToken);

    public Task<SaveCategoryResponse> UpdateAsync(SaveMonthCategory category, CancellationToken cancellationToken = default) =>
        PatchAsync<SaveCategoryResponse>(_resourceUri, new PatchMonthCategoryWrapper { Category = category }, cancellationToken);
}