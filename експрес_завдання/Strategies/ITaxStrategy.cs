namespace FinancialTransactionMonitor.Strategies;

public interface ITaxStrategy
{
    string Name { get; }
    decimal CalculateTax(decimal amount);
}
