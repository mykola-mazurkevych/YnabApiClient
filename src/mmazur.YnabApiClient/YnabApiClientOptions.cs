namespace mmazur.YnabApiClient;

public sealed record YnabApiClientOptions
{
    public Uri BaseUri { get; init; } = new("https://api.ynab.com/");
    public required string BearerToken { get; init; }
}