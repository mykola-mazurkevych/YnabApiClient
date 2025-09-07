using mmazur.YnabApiClient.V1.Models.Budgets;

namespace mmazur.YnabApiClient.Extensions;

internal static class EnumExtensions
{
    public static string ToCustomString(this BudgetType budgetType) =>
        budgetType switch
        {
            BudgetType.LastUsed => "last-used",
            BudgetType.Default => "default",
            _ => throw new NotSupportedException($"Budget type value {budgetType} is not supported")
        };
}