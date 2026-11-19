namespace FinancialTransactionMonitor.Strategies;

public class StandardTaxStrategy : ITaxStrategy
{
    public string Name => "Standard tax (18%)";

    public decimal CalculateTax(decimal amount) => amount * 0.18m;
}
