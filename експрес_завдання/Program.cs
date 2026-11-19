using FinancialTransactionMonitor.Controllers;
using FinancialTransactionMonitor.Decorators;
using FinancialTransactionMonitor.Models;
using FinancialTransactionMonitor.Observers;
using FinancialTransactionMonitor.Strategies;
using FinancialTransactionMonitor.Views;

var model = new TransactionModel(new StandardTaxStrategy());
model.AddObserver(new ConsoleLogger());
model.AddObserver(new EmailNotifier());

ITransactionProcessor processor = new BasicTransactionProcessor();
processor = new EncryptionDecorator(processor);
processor = new LoggingDecorator(processor);

var view = new TransactionView();
var controller = new TransactionController(model, view, processor);
controller.Run();

Console.WriteLine("Demo finished. Press any key to exit.");
if (!Console.IsInputRedirected)
    Console.ReadKey();
