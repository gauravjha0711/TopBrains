using System;
using System.Text;
public class Program
{
    public static void Main()
    {
        Dictionary<int,bool?> Attendance = new Dictionary<int, bool?>();
        StringBuilder ans = new StringBuilder("");
        int TotalPresent = 0;
        int TotalAbsent = 0;
        int NotMarked = 0;
        string input = Console.ReadLine();
        string[] inputId = input.Split(",");
        foreach(var part in inputId)
        {
            string[] parts = part.Split(":");
            int.TryParse(parts[0],out int Id);
            if (Id == 0)
            {
                continue;
            }
            if (parts[1] == "Present")
            {
                TotalPresent++;
                ans.AppendLine($"{Id} -> Present");
                Attendance[Id] = true;
            }
            else if (parts[1] == "Absent")
            {
                TotalAbsent++;
                ans.AppendLine($"{Id} -> Absent");
                Attendance[Id] = false;
            }
            else if (parts[1] == "")
            {
                NotMarked++;
                ans.AppendLine($"{Id} -> Not Marked");
                Attendance[Id] = null;
            }
        } 
        Console.WriteLine("Attendance Report");
        Console.WriteLine("------------------");
        Console.WriteLine(ans);
        Console.WriteLine($"Total Present: {TotalPresent}");
        Console.WriteLine($"Total Absent: {TotalAbsent}");
        Console.WriteLine($"Total Not Marked: {NotMarked}");
    }
}