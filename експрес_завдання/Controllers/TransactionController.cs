using FinancialTransactionMonitor.Decorators;
using FinancialTransactionMonitor.Models;
using FinancialTransactionMonitor.Strategies;
using FinancialTransactionMonitor.Views;

namespace FinancialTransactionMonitor.Controllers;

public class TransactionController
{
    private readonly TransactionModel model;
    private readonly TransactionView view;
    private readonly ITransactionProcessor processor;

    public TransactionController(TransactionModel model, TransactionView view, ITransactionProcessor processor)
    {
        this.model = model;
        this.view = view;
        this.processor = processor;
    }

    public void Run()
    {
        view.ShowHeader();
        decimal amount = view.ReadAmount();

        view.ShowStrategy(model.CurrentStrategyName);
        Transaction firstTransaction = model.ProcessTransaction(amount, processor);
        view.ShowResult(firstTransaction);

        view.ShowMessage("Changing strategy during execution...");
        model.SetTaxStrategy(new ITTaxStrategy());

        view.ShowStrategy(model.CurrentStrategyName);
        Transaction secondTransaction = model.ProcessTransaction(amount, processor);
        view.ShowResult(secondTransaction);
    }
}
