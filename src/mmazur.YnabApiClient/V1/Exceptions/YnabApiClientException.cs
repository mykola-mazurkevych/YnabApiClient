#pragma warning disable CA1032 // Implement standard exception constructors

namespace mmazur.YnabApiClient.V1.Exceptions;

public sealed class YnabApiClientException : Exception
{
    internal YnabApiClientException(string id, string name, string detail)
    {
        this.Id = id;
        this.Name = name;
        this.Detail = detail;
    }

    public string Id { get; }
    public string Name { get; }
    public string Detail { get; }
}