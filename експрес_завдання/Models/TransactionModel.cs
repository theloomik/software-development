using FinancialTransactionMonitor.Decorators;
using FinancialTransactionMonitor.Observers;
using FinancialTransactionMonitor.Strategies;

namespace FinancialTransactionMonitor.Models;

public class TransactionModel
{
    private ITaxStrategy taxStrategy;
    private readonly List<ITransactionObserver> observers = new();

    public TransactionModel(ITaxStrategy taxStrategy)
    {
        this.taxStrategy = taxStrategy;
    }

    public string CurrentStrategyName => taxStrategy.Name;

    public void SetTaxStrategy(ITaxStrategy newStrategy)
    {
        taxStrategy = newStrategy;
    }

    public void AddObserver(ITransactionObserver observer)
    {
        observers.Add(observer);
    }

    public Transaction ProcessTransaction(decimal amount, ITransactionProcessor processor)
    {
        decimal tax = taxStrategy.CalculateTax(amount);
        decimal finalAmount = amount - tax;
        string data = $"Amount: {finalAmount:0.00}; Tax: {tax:0.00}";
        string processedData = processor.Process(data);

        var transaction = new Transaction(amount, tax, finalAmount, processedData);

        foreach (ITransactionObserver observer in observers)
        {
            observer.Update(transaction);
        }

        return transaction;
    }
}
