namespace mmazur.YnabApiClient.V1.Transactions.Models;

public enum DebtTransactionType
{
    Payment,
    Refund,
    Fee,
    Interest,
    Escrow,
    BalanceAdjustment,
    Credit,
    Charge,
}