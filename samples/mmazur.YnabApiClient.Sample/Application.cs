#pragma warning disable CA1812 // Avoid uninstantiated internal classes
#pragma warning disable CS9113 // Parameter is unused

namespace mmazur.YnabApiClient.Sample;

internal sealed class Application(IYnabApiClient ynabApiClient) : IApplication
{
    public Task RunAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}