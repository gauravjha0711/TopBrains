using System;
public class Program
{
    public static void Main()
    {
        int sum=0;
        while (true)
        {
            Console.Write("Enter number to add, and 0 for stop: ");
            int num = Convert.ToInt32(Console.ReadLine());
            if(num > 0)
            {
                sum += num;
                Console.WriteLine($"Current sum is: {sum}");
            }
            else if (num < 0)
            {
                Console.Write("Negative number ignored. ");
                Console.WriteLine($"Current sum is: {sum}");
            }
            else if (num == 0)
            {
                Console.WriteLine($"Final sum of positive integers is: {sum}");
                return;
            }
        }
    }
}