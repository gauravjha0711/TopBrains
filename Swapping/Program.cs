using System;
public class Program
{
    public static void Main()
    {
        Console.Write("Enter first Number: ");
        int firstNumber = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter second Number: ");
        int secondNumber = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($"Before Swapping: First Number = {firstNumber}, Second Number = {secondNumber}");
        SwappingRef(ref firstNumber, ref secondNumber);
        Console.WriteLine($"After Swapping using Ref: First Number = {firstNumber}, Second Number = {secondNumber}");
        // SwappingOut(firstNumber, secondNumber, out firstNumber, out secondNumber);
        // Console.WriteLine($"After Swapping using Out: First Number = {firstNumber}, Second Number = {secondNumber}");
    }
    public static void SwappingRef(ref int a, ref int b)
    {
        a = a + b;
        b = a - b;
        a = a - b;
    }
    public static void SwappingOut(int a, int b, out int x, out int y)
    {
        x = a + b;
        y = x - b;
        x = x - y;
    }
}