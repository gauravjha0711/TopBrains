using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_Course_Registration_System
{
    // =========================
    // University System Class
    // =========================
    public class ArgumentException : Exception
    {
        public ArgumentException(string mes): base(mes)
        {
        }
    }
    public class UniversitySystem
    {
        public Dictionary<string, Course> AvailableCourses { get; private set; }
        public Dictionary<string, Student> Students { get; private set; }
        public List<Student> ActiveStudents => Students.Values.Where(s => s.RegisteredCourses.Count > 0).ToList();

        public UniversitySystem()
        {
            AvailableCourses = new Dictionary<string, Course>();
            Students = new Dictionary<string, Student>();
        }

        public void AddCourse(string code, string name, int credits, int maxCapacity = 50, List<string>? prerequisites = null)
        {
            // TODO:
            // 1. Throw ArgumentException if course code exists
            // 2. Create Course object
            // 3. Add to AvailableCourses
            if (AvailableCourses.ContainsKey(code))
            {
                throw new ArgumentException($"Course with code {code} already exists.");
            }
            Course newCourse = new Course(code, name, credits, maxCapacity, prerequisites);
            AvailableCourses.Add(code, newCourse);
            // throw new NotImplementedException();
        }

        public void AddStudent(string id, string name, string major, int maxCredits = 18, List<string>? completedCourses = null)
        {
            // TODO:
            // 1. Throw ArgumentException if student ID exists
            // 2. Create Student object
            // 3. Add to Students dictionary
            if (Students.ContainsKey(id))
            {
                throw new ArgumentException($"Student with ID {id} already exists.");
            }
            Student newStudent = new Student(id, name, major, maxCredits, completedCourses);
            Students.Add(id, newStudent);
            // throw new NotImplementedException();
        }

        public bool RegisterStudentForCourse(string studentId, string courseCode)
        {
            // TODO:
            // 1. Validate student and course existence
            // 2. Call student.AddCourse(course)
            // 3. Display meaningful messages
            if (!Students.ContainsKey(studentId))
            {
                throw new ArgumentException($"Student with ID {studentId} does not exist.");
            }
            if(!AvailableCourses.ContainsKey(courseCode))
            {
                throw new ArgumentException($"Course with code {courseCode} does not exist.");
            }
            Student student = Students[studentId];
            Course course = AvailableCourses[courseCode];
            if(student.AddCourse(course))
            {
                Console.WriteLine($"Student {student.Name} successfully registered for {course.CourseName}.");
                return true;
            }
            else
            {
                Console.WriteLine($"Failed to register student {student.Name} for {course.CourseName}.");
                return false;
            }
            // throw new NotImplementedException();
        }

        public bool DropStudentFromCourse(string studentId, string courseCode)
        {
            // TODO:
            // 1. Validate student existence
            // 2. Call student.DropCourse(courseCode)
            if(!Students.ContainsKey(studentId))
            {
                throw new ArgumentException($"Student with ID {studentId} does not exist.");
            }
            Student student = Students[studentId];
            if(student.DropCourse(courseCode))
            {
                Console.WriteLine($"Student {student.Name} successfully dropped course {courseCode}.");
                return true;
            }
            else
            {
                Console.WriteLine($"Failed to drop course {courseCode} for student {student.Name}.");
                return false;
            }
            // throw new NotImplementedException();
        }

        public void DisplayAllCourses()
        {
            // TODO:
            // Display course code, name, credits, enrollment info
            if(AvailableCourses.Count == 0)
            {
                Console.WriteLine("No courses available.");
            }
            else
            {
                foreach(var course in AvailableCourses.Values)
                {
                    Console.WriteLine($"{course.CourseCode}: {course.CourseName} ({course.Credits} credits) - {course.GetEnrollmentInfo()}");
                }
            }
            // throw new NotImplementedException();
        }

        public void DisplayStudentSchedule(string studentId)
        {
            // TODO:
            // Validate student existence
            // Call student.DisplaySchedule()
            if(!Students.ContainsKey(studentId))
            {
                throw new ArgumentException($"Student with ID {studentId} does not exist.");
            }
            Student student = Students[studentId];
            Console.WriteLine($"Schedule for {student.Name}:");
            student.DisplaySchedule();

            // throw new NotImplementedException();
        }

        public void DisplaySystemSummary()
        {
            // TODO:
            // Display total students, total courses, average enrollment
            Console.WriteLine($"Total Students: {Students.Count}");
            Console.WriteLine($"Total Courses: {AvailableCourses.Count}");
            if(AvailableCourses.Count > 0)
            {
                double averageEnrollment = AvailableCourses.Values.Average(c => c.CurrentEnrollment);
                Console.WriteLine($"Average Enrollment per Course: {averageEnrollment:F2}");
            }
            else
            {
                Console.WriteLine("Average Enrollment per Course: NO");
            }
            // throw new NotImplementedException();
        }
    }
}
