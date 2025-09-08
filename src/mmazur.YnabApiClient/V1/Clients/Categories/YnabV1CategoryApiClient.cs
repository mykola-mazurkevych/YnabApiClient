using mmazur.YnabApiClient.Infrastructure;
using mmazur.YnabApiClient.V1.Interfaces.Categories;
using mmazur.YnabApiClient.V1.Models.Categories;

namespace mmazur.YnabApiClient.V1.Clients.Categories;

internal sealed class YnabV1CategoryApiClient(IHttpClientFactory httpClientFactory, Uri baseUri, Guid categoryId, string bearerToken)
    : YnabApiClientBase(httpClientFactory), IYnabV1CategoryApiClient
{
    private readonly Uri _resourceUri = new(baseUri, $"{categoryId}/");

    public Task<CategoryResponse> GetAsync(CancellationToken cancellationToken = default) =>
        this.GetAsync<CategoryResponse>(_resourceUri, null, bearerToken, cancellationToken);

    public Task<SaveCategoryResponse> UpdateAsync(SaveCategory category, CancellationToken cancellationToken = default) =>
        this.PatchAsync<SaveCategoryResponse>(_resourceUri, new PatchCategoryWrapper { Category = category }, bearerToken, cancellationToken);
}