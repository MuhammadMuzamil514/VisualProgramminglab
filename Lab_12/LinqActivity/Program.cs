using System;
using System.Collections.Generic;
using System.Linq;

namespace linq_activity
{
    class Program
    {
        static void Main(string[] args)
        {
            // Part 1: LINQ to find even numbers in an array
            int[] numbers = new int[7] { 0, 1, 2, 3, 4, 5, 6 };
            IEnumerable<int> numQuery =
                from num in numbers
                where (num % 2) == 0
                select num;

            Console.WriteLine("Even numbers in the array:");
            foreach (int num in numQuery)
            {
                Console.Write($"{num} ");
            }
            Console.WriteLine();

            // Wait for user input before continuing
            Console.WriteLine("\nPress any key to continue to Student Tasks...");
            Console.ReadKey();

            // Part 2: Student Class tasks
            var sc = new StudentClass();
            sc.Task1And2(1, 90); // Execute Task 1 and 2

            // Keep the console window open
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }

    public class StudentClass
    {
        protected enum GradeLevel { FirstYear = 1, SecondYear, ThirdYear, FourthYear }

        protected class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int ID { get; set; }
            public GradeLevel Year { get; set; }
            public List<int> ExamScores { get; set; }
        }

        // Sample data
        protected static List<Student> students = new List<Student>
        {
            new Student {FirstName = "Terry", LastName = "Adams", ID = 120, Year = GradeLevel.SecondYear, ExamScores = new List<int>{ 99, 82, 81, 79}},
            new Student {FirstName = "Fadi", LastName = "Fakhouri", ID = 116, Year = GradeLevel.ThirdYear, ExamScores = new List<int>{ 99, 86, 90, 94}},
            new Student {FirstName = "Hanying", LastName = "Feng", ID = 117, Year = GradeLevel.FirstYear, ExamScores = new List<int>{ 93, 92, 80, 87}},
            new Student {FirstName = "Cesar", LastName = "Garcia", ID = 114, Year = GradeLevel.FourthYear, ExamScores = new List<int>{ 97, 89, 85, 82}},
            new Student {FirstName = "Debra", LastName = "Garcia", ID = 115, Year = GradeLevel.ThirdYear, ExamScores = new List<int>{ 35, 72, 91, 70}},
            new Student {FirstName = "Hugo", LastName = "Garcia", ID = 118, Year = GradeLevel.SecondYear, ExamScores = new List<int>{ 92, 90, 83, 78}},
            new Student {FirstName = "Sven", LastName = "Mortensen", ID = 113, Year = GradeLevel.FirstYear, ExamScores = new List<int>{ 88, 94, 65, 91}},
            new Student {FirstName = "Claire", LastName = "O'Donnell", ID = 112, Year = GradeLevel.FourthYear, ExamScores = new List<int>{ 75, 84, 91, 39}},
            new Student {FirstName = "Svetlana", LastName = "Omelchenko", ID = 111, Year = GradeLevel.SecondYear, ExamScores = new List<int>{ 97, 92, 81, 60}},
            new Student {FirstName = "Lance", LastName = "Tucker", ID = 119, Year = GradeLevel.ThirdYear, ExamScores = new List<int>{ 68, 79, 88, 92}},
            new Student {FirstName = "Michael", LastName = "Tucker", ID = 122, Year = GradeLevel.FirstYear, ExamScores = new List<int>{ 94, 92, 91, 91}},
            new Student {FirstName = "Eugene", LastName = "Zabokritski", ID = 121, Year = GradeLevel.FourthYear, ExamScores = new List<int>{ 96, 85, 91, 60}}
        };

        // Task 1: Query and display high scores for a specific exam and score threshold
        public void QueryHighScores(int exam, int score)
        {
            var highScores = from student in students
                             where student.ExamScores[exam] > score
                             select new { Name = student.FirstName, Score = student.ExamScores[exam] };

            Console.WriteLine("Task 1: High Scores for Exam {0} > {1}", exam, score);
            foreach (var item in highScores)
            {
                Console.WriteLine("{0,-15}{1}", item.Name, item.Score);
            }
            Console.WriteLine();
        }

        // Task 2: Display all students along with their average exam score
        public void DisplayStudentAverages()
        {
            var studentAverages = from student in students
                                  select new { student.FirstName, AverageScore = student.ExamScores.Average() };

            Console.WriteLine("Task 2: Student Averages");
            foreach (var item in studentAverages)
            {
                Console.WriteLine("{0,-15}{1:F2}", item.FirstName, item.AverageScore);
            }
            Console.WriteLine();
        }

        // Task 1 and Task 2 combined
        public void Task1And2(int exam, int score)
        {
            // Call Task 1
            QueryHighScores(exam, score);

            // Call Task 2
            DisplayStudentAverages();
        }
    }
}
