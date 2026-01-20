using System;
using System.Collections.Generic;
public class Program
{
    public static void Main()
    {
        Console.Write("Enter number: ");
        int n = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter upto: ");
        int upto = Convert.ToInt32(Console.ReadLine());
        List<int> table = new List<int>();
        for(int i = 1; i <= upto; i++)
        {
            table.Add(n * i);
        }
        foreach(var item in table)
        {
            Console.Write(item + " ");
        }
    }
}