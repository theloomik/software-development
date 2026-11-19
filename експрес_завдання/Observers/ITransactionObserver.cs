using FinancialTransactionMonitor.Models;

namespace FinancialTransactionMonitor.Observers;

public interface ITransactionObserver
{
    void Update(Transaction transaction);
}
