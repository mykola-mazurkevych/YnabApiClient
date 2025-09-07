namespace mmazur.YnabApiClient.Sample;

internal sealed class Application(IYnabApiClient ynabApiClient) : IApplication
{
    public async Task RunAsync(CancellationToken cancellationToken = default)
    {
        var userResponse = await ynabApiClient.V1.User.GetAsync(cancellationToken);
        Console.WriteLine(userResponse.User);
    }
}