using FinancialTransactionMonitor.Models;

namespace FinancialTransactionMonitor.Views;

public class TransactionView
{
    public void ShowHeader()
    {
        Console.WriteLine("=== FINANCIAL TRANSACTION MONITOR ===");
        Console.WriteLine("MVC + Strategy + Decorator + Observer");
        Console.WriteLine();
    }

    public decimal ReadAmount()
    {
        while (true)
        {
            Console.Write("Enter transaction amount: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount) && amount > 0)
                return amount;

            Console.WriteLine("Please enter a positive number.");
        }
    }

    public void ShowStrategy(string strategyName) => Console.WriteLine($"Strategy: {strategyName}");

    public void ShowResult(Transaction transaction)
    {
        Console.WriteLine($"Raw amount:   {transaction.Amount:0.00}");
        Console.WriteLine($"Tax:          {transaction.Tax:0.00}");
        Console.WriteLine($"Final amount: {transaction.FinalAmount:0.00}");
        Console.WriteLine($"Processed data: {transaction.ProcessedData}");
        Console.WriteLine();
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
        Console.WriteLine();
    }
}
