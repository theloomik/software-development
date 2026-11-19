namespace FinancialTransactionMonitor.Models;

public class Transaction
{
    public decimal Amount { get; }
    public decimal Tax { get; }
    public decimal FinalAmount { get; }
    public string ProcessedData { get; }

    public Transaction(decimal amount, decimal tax, decimal finalAmount, string processedData)
    {
        Amount = amount;
        Tax = tax;
        FinalAmount = finalAmount;
        ProcessedData = processedData;
    }
}
