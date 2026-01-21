using System;
public abstract class Shape
{
    public abstract double Area();
}
public class Circle : Shape
{
    public double Radius { get; set; }
    public override double Area()
    {
        return Math.PI * Radius * Radius;
    }
}
public class Rectangle : Shape
{
    public double Length { get; set; }
    public double Width { get; set; }
    public override double Area()
    {
        return Length * Width;
    }
}
public class Triangle : Shape
{
    public double Base { get; set; }
    public double Height { get; set; }
    public override double Area()
    {
        return 0.5 * Base * Height;
    }
}
public class Program
{
    public static void Main()
    {
        Console.WriteLine("Enter string for Circle: C r: ");
        Console.WriteLine("Enter string for Rectangle: R l w: ");
        Console.WriteLine("Enter string for Triangle: T b h: ");
        string input = Console.ReadLine();
        string[] parts = input.Split(' ');
        if (parts[0] == "C")
        {
            Circle circle = new Circle();
            circle.Radius = double.Parse(parts[1]);
            Console.WriteLine("Area of Circle: " + Math.Round(circle.Area(), 2));
        }
        else if (parts[0] == "R")
        {
            Rectangle rectangle = new Rectangle();
            rectangle.Length = double.Parse(parts[1]);
            rectangle.Width = double.Parse(parts[2]);
            Console.WriteLine("Area of Rectangle: " + Math.Round(rectangle.Area(), 2));
        }
        else if (parts[0] == "T")
        {
            Triangle triangle = new Triangle();
            triangle.Base = double.Parse(parts[1]);
            triangle.Height = double.Parse(parts[2]);
            Console.WriteLine("Area of Triangle: " + Math.Round(triangle.Area(), 2));
        }
        else
        {
            Console.WriteLine("Invalid Shape Type");
        }
    }
}