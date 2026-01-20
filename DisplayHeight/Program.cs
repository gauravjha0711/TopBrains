using System;
public class Program
{
    public static void Main()
    {
        Console.Write("Enter height in cm: ");
        int height = Convert.ToInt32(Console.ReadLine());
        if(0<=height && height <= 150)
        {
            Console.WriteLine("Short");
        }
        else if(151<=height && height <=180)
        {
            Console.WriteLine("Average");
        }
        else if(181<=height && height <=300)
        {
            Console.WriteLine("Tall");
        }
        else
        {
            Console.WriteLine("Invalid Input");
        }
    }
}