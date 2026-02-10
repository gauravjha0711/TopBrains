using System;
using System.Text.Json;
using System.Linq;
using System.Collections.Generic;
record Student(string Name, int Score);
public class Program
{
    public static void Main()
    {
        string[] items = {
            "Rahul:85",
            "Ankit:90",
            "Rahul:90",
            "Gaurav:94"
        };
        int minScore = 86;
        string jsonAns = BuildStudentJson(items,minScore);
        Console.WriteLine(jsonAns);
    }
    public static string BuildStudentJson(string[] items, int minScore)
    {
        List<Student> students = items.Select(item =>
        {
            var parts = item.Split(":");
            return new Student(parts[0],int.Parse(parts[1]));
        })
        .Where(s=>s.Score>=minScore)
        .OrderByDescending(s=>s.Score)
        .ThenBy(s=>s.Name)
        .ToList();
        return JsonSerializer.Serialize(students);
    }
}