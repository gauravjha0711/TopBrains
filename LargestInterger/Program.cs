using System;
public class Program
{
    public static void Main()
    {
        Console.Write("Enter first number: ");
        int a = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter second number: ");
        int b = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter third number: ");
        int c = Convert.ToInt32(Console.ReadLine());
        if(a>b && a>c)
        {
            Console.WriteLine($"Largest integer is: {a}");
        }
        else if(b>a && b>c)
        {
            Console.WriteLine($"Largest integer is: {b}");
        }
        else
        {
            Console.WriteLine($"Largest integer is: {c}");
        }
    }
}