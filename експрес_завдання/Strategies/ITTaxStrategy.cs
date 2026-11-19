namespace FinancialTransactionMonitor.Strategies;

public class ITTaxStrategy : ITaxStrategy
{
    public string Name => "IT tax (5%)";

    public decimal CalculateTax(decimal amount) => amount * 0.05m;
}
