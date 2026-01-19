using System;
public class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public int Marks { get; set; }
}
public class Program
{
    public static void Main()
    {
        List<Student> students = new List<Student>();
        Console.Write("Enter number of students: ");
        int n = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Enter details for student {i + 1} (Name Age Marks): ");
            string[] inputs = Console.ReadLine().Split(' ');
            Student student = new Student
            {
                Name = inputs[0],
                Age = Convert.ToInt32(inputs[1]),
                Marks = Convert.ToInt32(inputs[2])
            };
            students.Add(student);
        }
        var SortedStudents = students.OrderByDescending(s=>s.Marks).ThenBy(s=>s.Age);
        Console.WriteLine("Sorted Student Details:");
        foreach (var student in SortedStudents)
        {
            Console.WriteLine($"{student.Name} {student.Age} {student.Marks}");
        }
    }
}