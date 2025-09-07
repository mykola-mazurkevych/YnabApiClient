#pragma warning disable CA1826 // Do not use Enumerable methods on indexable collections

namespace mmazur.YnabApiClient.Sample;

internal sealed class Application(IYnabApiClient ynabApiClient) : IApplication
{
    public async Task RunAsync(CancellationToken cancellationToken = default)
    {
        var userResponse = await ynabApiClient.V1.User.GetAsync(cancellationToken);
        Console.WriteLine(userResponse.User);
        Console.WriteLine();

        var budgetWithAccountsResponse = await ynabApiClient.V1.Budgets.GetWithAccountsAsync(cancellationToken);
        var testBudgetWithAccounts = budgetWithAccountsResponse.Budgets.Single(budget => string.Equals(budget.Name, "test", StringComparison.OrdinalIgnoreCase));
        Console.WriteLine(testBudgetWithAccounts);
        Console.WriteLine();

        var budgetsResponse = await ynabApiClient.V1.Budgets.GetAsync(cancellationToken);
        var testBudget = budgetsResponse.Budgets.Single(budget => string.Equals(budget.Name, "test", StringComparison.OrdinalIgnoreCase));
        Console.WriteLine(testBudget);
        Console.WriteLine();

        var budgetSettingsResponse = await ynabApiClient.V1.Budgets[testBudget.Id].Settings.GetAsync(cancellationToken);
        Console.WriteLine(budgetSettingsResponse.Settings);
        Console.WriteLine();

        var accountsResponse = await ynabApiClient.V1.Budgets[testBudget.Id].Accounts.GetAsync(cancellationToken);
        Console.WriteLine(accountsResponse.Accounts);
        Console.WriteLine();

        var accountResponse = await ynabApiClient.V1.Budgets[testBudget.Id].Accounts[accountsResponse.Accounts[0].Id].GetAsync(cancellationToken);
        Console.WriteLine(accountResponse.Account);
        Console.WriteLine();

        ////var createAccount = new CreateAccount { Name = "Test Account", Type = AccountType.Cash, Balance = 0 };
        ////var createdAccountResponse = await ynabApiClient.V1.Budgets[testBudget.Id].Accounts.CreateAsync(createAccount, cancellationToken);
        ////Console.WriteLine(createdAccountResponse.Account);
        ////Console.WriteLine();

        var payeesResponse = await ynabApiClient.V1.Budgets[testBudget.Id].Payees.GetAsync(cancellationToken);
        Console.WriteLine(payeesResponse.Payees);
        Console.WriteLine();

        var payee = payeesResponse.Payees.FirstOrDefault();
        var payeeLocationsResponse = payee is null
            ? await ynabApiClient.V1.Budgets[testBudget.Id].PayeeLocations.GetAsync(cancellationToken)
            : await ynabApiClient.V1.Budgets[testBudget.Id].Payees[payee.Id].Locations.GetAsync(cancellationToken);
        Console.WriteLine(payeeLocationsResponse.PayeeLocations);
        Console.WriteLine();

        var payeeLocation = payeeLocationsResponse.PayeeLocations.FirstOrDefault();
        if (payeeLocation is not null)
        {
            var payeeLocationResponse = await ynabApiClient.V1.Budgets[testBudget.Id].PayeeLocations[payeeLocation.Id].GetAsync(cancellationToken);
            Console.WriteLine(payeeLocationResponse.PayeeLocation);
            Console.WriteLine();
        }
    }
}