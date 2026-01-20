using System;
public class Program
{
    public static void Main()
    {
        Console.Write("Enter radius: ");
        double radius = Convert.ToDouble(Console.ReadLine());
        double area = Math.PI * Math.Pow(radius, 2);
        Console.WriteLine($"Area of circle with radius {radius} is: {Math.Round(area,2)}");
    }
}