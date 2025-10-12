namespace mmazur.YnabApiClient.V1.Categories;

public interface IYnabV1CategoriesCategoryApiClient
{
    IYnabV1CategoryApiClient this[Guid categoryId] { get; }
}