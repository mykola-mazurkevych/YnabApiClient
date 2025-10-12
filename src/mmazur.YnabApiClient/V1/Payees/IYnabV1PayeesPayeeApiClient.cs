namespace mmazur.YnabApiClient.V1.Payees;

public interface IYnabV1PayeesPayeeApiClient
{
    IYnabV1PayeeApiClient this[Guid payeeId] { get; }
}