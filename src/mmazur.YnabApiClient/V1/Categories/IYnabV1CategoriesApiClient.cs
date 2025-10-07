#pragma warning disable CA1043 // Use integral or string argument for indexers

namespace mmazur.YnabApiClient.V1.Categories;

public interface IYnabV1CategoriesApiClient 
    : IYnabV1CategoriesGetApiClient
{
    IYnabV1CategoryApiClient this[Guid categoryId] { get; }
}