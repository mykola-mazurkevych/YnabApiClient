namespace mmazur.YnabApiClient.V1.Models.Transactions;

internal static class TransactionTypeExtensions
{
    public static string ToCustomString(this TransactionType transactionType) =>
        transactionType switch
        {
            TransactionType.Uncategorized => "uncategorized",
            TransactionType.Unapproved => "unapproved",
            _ => throw new NotSupportedException($"Transaction type value {transactionType} is not supported")
        };
}