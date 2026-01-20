using System;
public class Program
{
    public static void Main()
    {
        Console.Write("Enter feet convert into cm: ");
        int feet = Convert.ToInt32(Console.ReadLine());
        double cm = feet * 30.48;
        Console.WriteLine($"{feet} feet is equal to {Math.Round(cm,2)} cm");
    }
}