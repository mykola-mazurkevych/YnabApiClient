namespace mmazur.YnabApiClient.Exceptions;

public sealed class YnabApiClientError(string id, string name, string detail) : Exception
{
    public string Id { get; } = id;
    public string Name { get; } = name;
    public string Detail { get; } = detail;
}