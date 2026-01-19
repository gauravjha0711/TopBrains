using System;
public class Program
{
    public static void Main()
    {
        Console.Write("Enter start range: ");
        int startRange = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter end range: ");
        int endRange = Convert.ToInt32(Console.ReadLine());
        int count = 0;
        for(int i = startRange; i <= endRange; i++)
        {
            if (!IsPrime(i))
            {
                int sum = DigitSum(i);
                int product = sum*sum;

                int square = i * i;
                int sqSum = DigitSum(square);
                if (sqSum == product)
                {
                    count++;
                }
            }
        }
        Console.WriteLine("Count of Lucky Winners: " + count);
    }
    static int DigitSum(int num)
    {
        int sum = 0;
        while (num > 0)
        {
            sum += num % 10;
            num /= 10;
        }
        return sum;
    }
    static bool IsPrime(int num)
    {
        if (num <= 1)
            return false;

        for (int i = 2; i * i <= num; i++)
        {
            if (num % i == 0)
                return false;
        }
        return true;
    }
}