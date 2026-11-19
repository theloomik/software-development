using FinancialTransactionMonitor.Models;

namespace FinancialTransactionMonitor.Observers;

public class EmailNotifier : ITransactionObserver
{
    public void Update(Transaction transaction) =>
        Console.WriteLine($"[Observer] EmailNotifier: notification sent for {transaction.FinalAmount:0.00}");
}
