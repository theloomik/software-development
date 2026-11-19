using FinancialTransactionMonitor.Models;

namespace FinancialTransactionMonitor.Observers;

public class ConsoleLogger : ITransactionObserver
{
    public void Update(Transaction transaction) =>
        Console.WriteLine($"[Observer] ConsoleLogger: final amount is {transaction.FinalAmount:0.00}");
}
