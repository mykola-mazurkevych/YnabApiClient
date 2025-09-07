namespace mmazur.YnabApiClient.Sample;

internal interface IApplication
{
    Task RunAsync(CancellationToken cancellationToken = default);
}