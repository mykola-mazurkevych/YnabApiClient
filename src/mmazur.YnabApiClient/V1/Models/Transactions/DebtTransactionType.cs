namespace mmazur.YnabApiClient.V1.Models.Transactions;

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