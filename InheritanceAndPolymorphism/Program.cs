using System;
public abstract class Employee
{
    public abstract decimal CalculateSalary();
}
public class HourlyEmployee : Employee
{
    public decimal Hour { get; set; }
    public decimal rate { get; set; }
    public override decimal CalculateSalary()
    {
        return Hour * rate;
    }
}
public class SalariedEmployee : Employee
{
    public decimal MonthlySalary { get; set; }
    public override decimal CalculateSalary()
    {
        return MonthlySalary;
    }
}
public class CommissionEmployee : Employee
{
    public decimal BaseSalary { get; set; }
    public decimal Commission { get; set; }
    public override decimal CalculateSalary()
    {
        return BaseSalary + Commission;
    }
}
public class Program
{
    public static void Main()
    {
        Console.Write("Enter Employee Type (1-Hourly, 2-Salaried, 3-Commission): ");
        int choice = int.Parse(Console.ReadLine());
        if (choice == 1)
        {
            HourlyEmployee hourlyEmployee = new HourlyEmployee();
            Console.Write("Enter Hours Worked: ");
            hourlyEmployee.Hour = decimal.Parse(Console.ReadLine());
            Console.Write("Enter Hourly Rate: ");
            hourlyEmployee.rate = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Total Pay: " + Math.Round(hourlyEmployee.CalculateSalary(), 2));
        }
        else if (choice == 2)
        {
            SalariedEmployee salariedEmployee = new SalariedEmployee();
            Console.Write("Enter Monthly Salary: ");
            salariedEmployee.MonthlySalary = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Total Pay: " + Math.Round(salariedEmployee.CalculateSalary(), 2));
        }
        else if (choice == 3)
        {
            CommissionEmployee commissionEmployee = new CommissionEmployee();
            Console.Write("Enter Base Salary: ");
            commissionEmployee.BaseSalary = decimal.Parse(Console.ReadLine());
            Console.Write("Enter Commission Amount: ");
            commissionEmployee.Commission = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Total Pay: " + Math.Round(commissionEmployee.CalculateSalary(), 2));
        }
        else
        {
            Console.WriteLine("Invalid Choice");
        }   
    }
}