using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.Exam
{
    public class Student
    {
        public string? StudentName { get; }
        public List<Course> Courses { get; set; }

        public Student(string? name)
        {
            StudentName = name;
            Courses = new List<Course>();
        }

        public void Enroll(Course course)
        {
            // Prevent duplicate enrollments and disallow "OOP"
            if (course.CourseName == "OOP")
            {
                Console.WriteLine($"{StudentName} cannot enroll in {course.CourseName}.");
                return;
            }

            if (!Courses.Exists(c => c.CourseName == course.CourseName))
            {
                Courses.Add(course);
            }
            else
            {
                Console.WriteLine($"{StudentName} is already enrolled in {course.CourseName}.");
            }
        }

        public void ShowCourses()
        {
            Console.WriteLine($"{StudentName} is enrolled in the following courses:");
            foreach (var course in Courses)
            {
                Console.WriteLine($"- {course.CourseName}");
            }
        }
    }

    public class Course
    {
        public string CourseName { get; }

        public Course(string? name)
        {
            CourseName = name ?? "Mathematics"; // Default to Mathematics if name is null
        }
    }

    class Program
    {
        static void Main()
        {
            var student = new Student("John");
            student.Enroll(new Course("Mathematics"));
            student.Enroll(new Course("Physics"));
            Course objectOrientedProgramming = new Course("OOP");
            student.Enroll(objectOrientedProgramming); // This will be ignored

            // Example to show the courses
            student.ShowCourses();
        }
    }
}