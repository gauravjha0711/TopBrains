using System;
using System.Collections.Generic;
using System.Linq;
public class InsufficientBalanceException : Exception
{
    public InsufficientBalanceException(string msg)  : base(msg){}
}
public class MinimumBalanceException : Exception
{
    public MinimumBalanceException(string msg)  : base(msg){}
}
public class InvalidTransactionException : Exception
{
    public InvalidTransactionException(string msg)  : base(msg){}
}
public abstract class BankAccount{
    public int AccountNumber { get; set; }
    public string CustomerName { get; set; }
    public double Balance { get; set; }
    public List<string> Transactions { get; set; } = new List<string>();
    public virtual void Deposit(double amount)
    {
        Balance += amount;
        Transactions.Add($"Deposited: {amount}");
    }
    public virtual void Withdraw(double amount)
    {
        if (amount > Balance)
            throw new InsufficientBalanceException("Not enough balance");

        Balance -= amount;
        Transactions.Add($"Withdrawn: {amount}");
    }
    public abstract double CalculateInterest();
}
public class SavingsAccount : BankAccount
{
    private const double MinBalance = 2000;

    public override void Withdraw(double amount)
    {
        if (Balance - amount < MinBalance)
            throw new MinimumBalanceException("Minimum balance rule violated");

        base.Withdraw(amount);
    }

    public override double CalculateInterest()
    {
        return Balance * 0.04;
    }
}
public class CurrentAccount : BankAccount
{
    private const double OverdraftLimit = 10000;

    public override void Withdraw(double amount)
    {
        if (amount > Balance + OverdraftLimit)
            throw new InsufficientBalanceException("Overdraft limit exceeded");

        Balance -= amount;
        Transactions.Add($"Withdrawn with overdraft: {amount}");
    }

    public override double CalculateInterest()
    {
        return 0;
    }
}
public class LoanAccount : BankAccount
{
    public override void Deposit(double amount)
    {
        throw new InvalidTransactionException("Deposit not allowed in Loan Account");
    }

    public override double CalculateInterest()
    {
        return Balance * 0.08;
    }
}
public class Program
{
    static List<BankAccount> accounts = new List<BankAccount>();
    public static void Transfer(BankAccount from, BankAccount to, double amount)
    {
        from.Withdraw(amount);
        to.Deposit(amount);
        from.Transactions.Add($"Transferred {amount} to {to.AccountNumber}");
        to.Transactions.Add($"Received {amount} from {from.AccountNumber}");
    }

    public static void Main()
    {
        accounts.Add(new SavingsAccount
        {
            AccountNumber = 101,
            CustomerName = "Ravi",
            Balance = 60000
        });

        accounts.Add(new CurrentAccount
        {
            AccountNumber = 102,
            CustomerName = "Amit",
            Balance = 30000
        });

        accounts.Add(new LoanAccount
        {
            AccountNumber = 103,
            CustomerName = "Rohit",
            Balance = 100000
        });
        while (true)
        {
            Console.WriteLine("1. View All Accounts");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Transfer Money");
            Console.WriteLine("5. Calculate Interest");
            Console.WriteLine("6. LINQ Reports");
            Console.WriteLine("7. Transaction History");
            Console.WriteLine("0. Exit");
            Console.Write("Enter choice: ");
            int choice = int.Parse(Console.ReadLine());
            try
            {
                switch (choice)
                {
                    case 1:
                        foreach (var acc in accounts)
                        {
                            Console.WriteLine($"{acc.AccountNumber} | {acc.CustomerName} | {acc.Balance} | {acc.GetType().Name}");
                        }
                        break;
                    case 2:
                        Console.Write("Enter Account No: ");
                        int dAcc = int.Parse(Console.ReadLine());
                        Console.Write("Enter Amount: ");
                        double dAmt = double.Parse(Console.ReadLine());

                        accounts.First(a => a.AccountNumber == dAcc).Deposit(dAmt);
                        Console.WriteLine("Deposit Successful");
                        break;

                    case 3:
                        Console.Write("Enter Account No: ");
                        int wAcc = int.Parse(Console.ReadLine());
                        Console.Write("Enter Amount: ");
                        double wAmt = double.Parse(Console.ReadLine());

                        accounts.First(a => a.AccountNumber == wAcc).Withdraw(wAmt);
                        Console.WriteLine("Withdrawal Successful");
                        break;

                    case 4:
                        Console.Write("From Account No: ");
                        int fromAcc = int.Parse(Console.ReadLine());
                        Console.Write("To Account No: ");
                        int toAcc = int.Parse(Console.ReadLine());
                        Console.Write("Amount: ");
                        double amt = double.Parse(Console.ReadLine());

                        Transfer(
                            accounts.First(a => a.AccountNumber == fromAcc),
                            accounts.First(a => a.AccountNumber == toAcc),
                            amt
                        );

                        Console.WriteLine("Transfer Successful");
                        break;

                    case 5:
                        foreach (var acc in accounts)
                        {
                            Console.WriteLine($"{acc.CustomerName} Interest: {acc.CalculateInterest()}");
                        }
                        break;

                    case 6:
                        Console.WriteLine("\n--- Balance > 50000 ---");
                        accounts.Where(a => a.Balance > 50000)
                                .ToList()
                                .ForEach(a => Console.WriteLine(a.CustomerName));

                        Console.WriteLine("\n--- Total Bank Balance ---");
                        Console.WriteLine(accounts.Sum(a => a.Balance));

                        Console.WriteLine("\n--- Top 3 Richest Accounts ---");
                        accounts.OrderByDescending(a => a.Balance)
                                .Take(3)
                                .ToList()
                                .ForEach(a => Console.WriteLine(a.CustomerName));

                        Console.WriteLine("\n--- Group By Account Type ---");
                        var groups = accounts.GroupBy(a => a.GetType().Name);
                        foreach (var g in groups)
                        {
                            Console.WriteLine(g.Key);
                            foreach (var acc in g)
                                Console.WriteLine("  " + acc.CustomerName);
                        }

                        Console.WriteLine("\n--- Customers Starting with R ---");
                        accounts.Where(a => a.CustomerName.StartsWith("R"))
                                .ToList()
                                .ForEach(a => Console.WriteLine(a.CustomerName));
                        break;

                    case 7:
                        Console.Write("Enter Account No: ");
                        int tAcc = int.Parse(Console.ReadLine());

                        var account = accounts.First(a => a.AccountNumber == tAcc);
                        foreach (var t in account.Transactions)
                        {
                            Console.WriteLine(t);
                        }
                        break;

                    case 0:
                        return;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
