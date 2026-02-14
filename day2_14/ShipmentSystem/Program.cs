using System;
using System.Text.RegularExpressions;
public class Shipment
{
    public string ShipmentCode { get; set;}
    public string TransportMode { get; set; }
    public double Weight { get; set; }
    public int StorageDays { get; set; }
}
public class ShipmentDetails : Shipment
{
    public bool ValidateShipmentCode()
    {
        string pattern = @"^GC#\d{4}$";
        return Regex.IsMatch(ShipmentCode,pattern);
    }
    public double CalculateTotalCost()
    {
        double Rate = 0;
        if(string.Equals(TransportMode, "Sea", StringComparison.OrdinalIgnoreCase))
        {
            Rate = 15.00;
        }
        else if (string.Equals(TransportMode, "Air", StringComparison.OrdinalIgnoreCase))
        {
            Rate = 50.00;
        }
        else if (string.Equals(TransportMode, "Land", StringComparison.OrdinalIgnoreCase))
        {
            Rate = 25.00;
        }
        return Math.Round(((Weight*Rate)+Math.Sqrt(StorageDays)),2);
    }
}
public class Program
{
    public static void Main()
    {
        ShipmentDetails shipmentDetails = new ShipmentDetails();
        Console.Write("Enter Input Id: ");
        shipmentDetails.ShipmentCode = Console.ReadLine();
        if (!shipmentDetails.ValidateShipmentCode())
        {
            Console.WriteLine("Invalid Shipment Code");
            return;
        }
        else
        {
            Console.Write("Enter Mode: ");
            shipmentDetails.TransportMode = Console.ReadLine();
            Console.Write("Enter Weight: ");
            shipmentDetails.Weight = double.Parse(Console.ReadLine());
            Console.Write("Enter Storage: ");
            shipmentDetails.StorageDays = int.Parse(Console.ReadLine());
            Console.WriteLine($"The total shipping cost is {shipmentDetails.CalculateTotalCost():F2}");
        }
    }
}