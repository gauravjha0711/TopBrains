using System;
public class Program
{
    public static void Main()
    {
        Console.Write("Enter Initial Balance: ");
        double initialBalance = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter number of transactions: ");
        int n = Convert.ToInt32(Console.ReadLine());
        for(int i = 0; i < n; i++)
        {
            Console.Write("Enter transaction amount (positive for deposit, negative for withdrawal): ");
            double transaction = Convert.ToDouble(Console.ReadLine());
            if(transaction < 0 && Math.Abs(transaction) > initialBalance)
            {
                Console.WriteLine("Insufficient funds for this withdrawal.");
                return;
            }
            else
            {
                initialBalance += transaction;
            }
        }
        Console.WriteLine($"Final Balance: {initialBalance}");
    }
}