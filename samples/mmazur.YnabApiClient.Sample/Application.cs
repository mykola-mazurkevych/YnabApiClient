#pragma warning disable CA1812 // Avoid uninstantiated internal classes
#pragma warning disable CA1826 // Do not use Enumerable methods on indexable collections

using mmazur.YnabApiClient.V1.Accounts.Models;
using mmazur.YnabApiClient.V1.Transactions.Models;

namespace mmazur.YnabApiClient.Sample;

internal sealed class Application(IYnabApiClient ynabApiClient) : IApplication
{
    public async Task RunAsync(CancellationToken cancellationToken = default)
    {
        var budgetId = await GetBudgetIdAsync("test", cancellationToken).ConfigureAwait(false);

        var accountName = $"Test Account {DateTimeOffset.UtcNow.Ticks}";
        var accountId = await GetAccountIdAsync(budgetId, accountName, cancellationToken).ConfigureAwait(false) ??
                        await CreateAccountAsync(budgetId, accountName, cancellationToken).ConfigureAwait(false);

        var payeeId = await GetPayeeIdAsync(budgetId, cancellationToken).ConfigureAwait(false);

        var categoryId = await GetCategoryIdAsync(budgetId, cancellationToken).ConfigureAwait(false);

        await CreateTransactionAsync(budgetId, accountId, categoryId, payeeId, cancellationToken).ConfigureAwait(false);
    }

    private async Task<Guid> GetBudgetIdAsync(string name, CancellationToken cancellationToken)
    {
        var budgetSummaryResponse =
            await ynabApiClient.V1.Budgets.GetAsync(cancellationToken).ConfigureAwait(false) ??
            throw new InvalidOperationException("Failed to retrieve budgets.");

        var budgetSummary = budgetSummaryResponse.Budgets.FirstOrDefault(summary => string.Equals(summary.Name, name, StringComparison.OrdinalIgnoreCase)) ??
                            throw new InvalidOperationException($"Budget '{name}' not found.");

        return budgetSummary.Id;
    }

    private async Task<Guid?> GetAccountIdAsync(Guid budgetId, string name, CancellationToken cancellationToken)
    {
        var accountsResponse =
            await ynabApiClient.V1.Budgets[budgetId].Accounts.GetAsync(cancellationToken).ConfigureAwait(false) ??
            throw new InvalidOperationException("Failed to retrieve accounts.");

        var account = accountsResponse.Accounts.FirstOrDefault(a => string.Equals(a.Name, name, StringComparison.OrdinalIgnoreCase));

        return account?.Id;
    }

    private async Task<Guid> CreateAccountAsync(Guid budgetId, string name, CancellationToken cancellationToken)
    {
        var saveAccount = new SaveAccount { Name = name, Type = AccountType.Cash, Balance = 0 };
        var accountResponse = await ynabApiClient.V1.Budgets[budgetId].Accounts.CreateAsync(saveAccount, cancellationToken).ConfigureAwait(false);

        if (accountResponse.Account is null)
        {
            throw new InvalidOperationException("Failed to create account.");
        }

        return accountResponse.Account.Id;
    }

    private async Task<Guid> GetCategoryIdAsync(Guid budgetId, CancellationToken cancellationToken)
    {
        var categoriesResponse =
            await ynabApiClient.V1.Budgets[budgetId].Categories.GetAsync(cancellationToken).ConfigureAwait(false) ??
            throw new InvalidOperationException("Failed to retrieve categories.");

        if (categoriesResponse.CategoryGroups.Count == 0 ||
            categoriesResponse.CategoryGroups[0].Categories.Count == 0)
        {
            throw new InvalidOperationException("No categories found.");
        }

        return categoriesResponse.CategoryGroups[0].Categories[0].Id;
    }

    private async Task<Guid?> GetPayeeIdAsync(Guid budgetId, CancellationToken cancellationToken)
    {
        var payeesResponse =
            await ynabApiClient.V1.Budgets[budgetId].Payees.GetAsync(cancellationToken).ConfigureAwait(false) ??
            throw new InvalidOperationException("Failed to retrieve payees.");

        var payee = payeesResponse.Payees.FirstOrDefault();

        return payee?.Id;
    }

    private async Task CreateTransactionAsync(
        Guid budgetId,
        Guid accountId,
        Guid categoryId,
        Guid? payeeId,
        CancellationToken cancellationToken)
    {
        var newTransaction = new NewTransaction
        {
            AccountId = accountId,
            Date = DateOnly.FromDateTime(DateTime.UtcNow),
            Amount = -5000,
            PayeeId = payeeId,
            CategoryId = categoryId,
            ClearedStatus = TransactionClearedStatus.Cleared
        };

        var transactionResponse = await ynabApiClient.V1.Budgets[budgetId].Transactions.CreateAsync(newTransaction, cancellationToken).ConfigureAwait(false);

        if (transactionResponse.Transaction is null)
        {
            throw new InvalidOperationException("Failed to create transaction.");
        }
    }
}