using System;
public class Program
{
    public static void Main()
    {
        Console.Write("Enter size of array: ");
        int n = Convert.ToInt32(Console.ReadLine());
        string[] arr = new string[n];
        Console.WriteLine("Enter array elements:");
        for(int i = 0; i < n; i++)
        {
            arr[i] = Console.ReadLine();
        }
        int sum = 0;
        foreach(var item in arr)
        {
            sum += int.TryParse(item, out int val) ? val : 0;
        }
        Console.WriteLine($"Sum of valid integers in array: {sum}");
    }
}