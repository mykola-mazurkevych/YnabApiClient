namespace mmazur.YnabApiClient.V1.Models.Budgets;

internal static class BudgetTypExtensions
{
    public static string ToCustomString(this BudgetType budgetType) =>
        budgetType switch
        {
            BudgetType.LastUsed => "last-used",
            BudgetType.Default => "default",
            _ => throw new NotSupportedException($"Budget type value {budgetType} is not supported")
        };
}