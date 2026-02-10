using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace University_Course_Registration_System
{
     // =========================
    // Program (Menu-Driven)
    // =========================
    class Program
    {
        static void Main()
        {
            UniversitySystem system = new UniversitySystem();
            bool exit = false;

            Console.WriteLine("Welcome to University Course Registration System");

            while (!exit)
            {
                Console.WriteLine("\n1. Add Course");
                Console.WriteLine("2. Add Student");
                Console.WriteLine("3. Register Student for Course");
                Console.WriteLine("4. Drop Student from Course");
                Console.WriteLine("5. Display All Courses");
                Console.WriteLine("6. Display Student Schedule");
                Console.WriteLine("7. Display System Summary");
                Console.WriteLine("8. Exit");

                Console.Write("Enter choice: ");
                int choice = int.Parse(Console.ReadLine()??"0");

                try
                {
                    // TODO:
                    // Implement menu handling logic using switch-case
                    // Prompt user inputs
                    // Call appropriate UniversitySystem methods

                    switch(choice){
                        case 1:
                            Console.Write("Course Code: ");
                            string code = Console.ReadLine()??"";
                            Console.Write("Course Name: ");
                            string name = Console.ReadLine()??"";
                            Console.Write("Credits: ");
                            int credits = int.Parse(Console.ReadLine()??"0");
                            Console.Write("Max Capacity (default 50): ");
                            int capacityInput = int.Parse(Console.ReadLine()??"50");
                            Console.Write("Prerequisites (comma separated, optional): ");
                            string prereqInput = Console.ReadLine()??"";
                            List<string> prereqs = prereqInput.Split(',').Select(s => s.Trim()).Where(s => !string.IsNullOrEmpty(s)).ToList();
                            system.AddCourse(code, name, credits, capacityInput, prereqs);
                            Console.WriteLine("Course added successfully.");
                            break;
                        
                        case 2:
                            Console.Write("Student ID: ");
                            string id = Console.ReadLine()??"";
                            Console.Write("Name: ");
                            string studentName = Console.ReadLine()??"";
                            Console.Write("Major: ");
                            string major = Console.ReadLine()??"";
                            Console.Write("Max Credits (default 18): ");
                            int maxCreditsInput = int.Parse(Console.ReadLine()??"18");
                            Console.Write("Completed Courses (comma separated, optional): ");
                            string completedInput = Console.ReadLine()??"";
                            List<string> completedCourses = completedInput.Split(',').Select(s => s.Trim()).Where(s => !string.IsNullOrEmpty(s)).ToList();
                            system.AddStudent(id, studentName, major, maxCreditsInput, completedCourses);
                            Console.WriteLine("Student added successfully.");
                            break;
                        case 3:
                            Console.Write("Student ID: ");
                            string regStudentId = Console.ReadLine()??"";
                            Console.Write("Course Code: ");
                            string regCourseCode = Console.ReadLine()??"";
                            system.RegisterStudentForCourse(regStudentId, regCourseCode);
                            break;
                        case 4:
                            Console.Write("Student ID: ");
                            string dropStudentId = Console.ReadLine()??"";
                            Console.Write("Course Code: ");
                            string dropCourseCode = Console.ReadLine()??"";
                            system.DropStudentFromCourse(dropStudentId, dropCourseCode);
                            break;
                        case 5:
                            system.DisplayAllCourses();
                            break;
                        case 6:
                            Console.Write("Student ID: ");
                            string schedStudentId = Console.ReadLine()??"";
                            system.DisplayStudentSchedule(schedStudentId);
                            break;
                        case 7:
                            system.DisplaySystemSummary();
                            break;
                        case 8:
                            exit = true;
                            Console.WriteLine("Exiting system!");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}

