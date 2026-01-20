using System;
using System.Collections;
public class Program
{
    public static void Main()
    {
        ArrayList arrayList = new ArrayList();
        Console.Write("Enter number of elements: ");
        int n = Convert.ToInt32(Console.ReadLine());
        for(int i = 0; i < n; i++)
        {
            Console.Write($"Enter element {i + 1}: ");
            String element = Console.ReadLine();
            arrayList.Add(element);
        }
        int sum = 0;
        foreach(var item in arrayList)
        {
            if(int.TryParse(item.ToString(), out int number))
            {
                sum += number;
            }
        }
        Console.WriteLine($"Sum of integer elements: {sum}");
    }
}