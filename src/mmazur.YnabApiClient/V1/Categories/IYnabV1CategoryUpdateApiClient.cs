using mmazur.YnabApiClient.V1.Categories.Models;

namespace mmazur.YnabApiClient.V1.Categories;

public interface IYnabV1CategoryUpdateApiClient
{
    /// <summary>
    /// Update a category
    /// </summary>
    /// <param name="category">Category to update.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<SaveCategoryResponse> UpdateAsync(SaveCategory category, CancellationToken cancellationToken = default);
}