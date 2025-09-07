namespace mmazur.YnabApiClient.Sample;

internal sealed class Application(IYnabApiClient ynabApiClient) : IApplication
{
    public async Task RunAsync(CancellationToken cancellationToken = default)
    {
        var userResponse = await ynabApiClient.V1.User.GetAsync(cancellationToken);
        Console.WriteLine(userResponse.User);

        var budgetsResponse = await ynabApiClient.V1.Budgets.GetAsync(cancellationToken);
        var testBudget = budgetsResponse.Budgets.Single(budget => string.Equals(budget.Name, "test", StringComparison.OrdinalIgnoreCase));
        Console.WriteLine(testBudget);

        var budgetSettingsResponse = await ynabApiClient.V1.Budgets[testBudget.Id].Settings.GetAsync(cancellationToken);
        Console.WriteLine(budgetSettingsResponse.Settings);
    }
}