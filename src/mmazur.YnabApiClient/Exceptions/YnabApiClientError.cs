#pragma warning disable CA1710 // Identifiers should have correct syntax
#pragma warning disable CA1032 // Implement standard exception constructors

namespace mmazur.YnabApiClient.Exceptions;

public sealed class YnabApiClientError : Exception
{
    internal YnabApiClientError(string id, string name, string detail)
    {
        this.Id = id;
        this.Name = name;
        this.Detail = detail;
    }

    public string Id { get; }
    public string Name { get; }
    public string Detail { get; }
}