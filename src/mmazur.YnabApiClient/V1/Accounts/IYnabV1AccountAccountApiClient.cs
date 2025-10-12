namespace mmazur.YnabApiClient.V1.Accounts;

public interface IYnabV1AccountAccountApiClient
{
    IYnabV1AccountApiClient this[Guid accountId] { get; }
}