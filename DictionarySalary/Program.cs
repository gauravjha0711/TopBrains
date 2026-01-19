using System;
public class Program
{
    public static void Main()
    {
        // employeeId, salary
        Dictionary<int, int> DictionarySalary = new Dictionary<int, int>();
        Console.Write("Enter number of employees: ");
        int n = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Enter details for employee {i + 1} (ID Salary): ");
            string[] inputs = Console.ReadLine().Split(' ');
            int empId = Convert.ToInt32(inputs[0]);
            int salary = Convert.ToInt32(inputs[1]);
            DictionarySalary[empId] = salary;
        }
        Console.Write("Enter number of employee Id space separated to get total salary: ");
        string[] empIdsInput = Console.ReadLine().Split(' ');
        int totalSalary = 0;
        foreach (string idStr in empIdsInput)
        {
            int empId = Convert.ToInt32(idStr);
            if (DictionarySalary.ContainsKey(empId))
            {
                totalSalary += DictionarySalary[empId];
            }
        }
        Console.WriteLine($"Total Salary: {totalSalary}");
    }
}