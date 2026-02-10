using System;
public class Program
{
    public static void Main()
    {
        double?[] values = { 10.555, null, 20.444, null, 30.111 };
        double? result = average(values);
        Console.WriteLine(result.HasValue ? result.ToString() : "null");
    }
    public static double? average(double?[] values)
    {
        double sum = 0;
        int count = 0;
        foreach(double? val in values)
        {
            if (val.HasValue)
            {
                sum += val.Value;
                count++;
            }
        }
        if (count == 0)
        {
            return null;
        }
        double average = sum/count;
        return Math.Round(average,2,MidpointRounding.AwayFromZero);
    }
}