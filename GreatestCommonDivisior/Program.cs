using System;
public class Program
{
    public static void Main()
    {
        Console.Write("Enter first number: ");
        int a = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter second number: ");
        int b = Convert.ToInt32(Console.ReadLine());
        while(b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        Console.WriteLine($"Greatest Common Divisor is: {a}");
    }
}