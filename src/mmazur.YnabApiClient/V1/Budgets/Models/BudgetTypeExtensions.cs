namespace mmazur.YnabApiClient.V1.Budgets.Models;

internal static class BudgetTypeExtensions
{
    public static string ToCustomString(this BudgetType budgetType) =>
        budgetType switch
        {
            BudgetType.LastUsed => "last-used",
            BudgetType.Default => "default",
            _ => throw new NotSupportedException($"Budget type value {budgetType} is not supported")
        };
}