using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week01
{
    internal class Administration
    {
        private List<Student> students = new();
        private IEnumerable<int> StudentNumbers => students.Select(student => student.StudentNumber);

        public void AddStudent(Student student)
        {
            if (!StudentNumbers.Contains(student.StudentNumber))
            {
                students.Add(student);
            }
        }

        public void Run()
        {
            
        }

        private void PromptMenu()
        {
            Console.WriteLine("Grade Administration System");
            Console.WriteLine("1) Add student.");
            Console.WriteLine("2) Remove student.");
            Console.WriteLine("3) Show student's grades.");
            Console.WriteLine("4) Add grade.");
            Console.WriteLine("5) Remove grade.");
            Console.WriteLine("6) Freeze grade.");
            Console.WriteLine("7) Exit.");

            int input;
            while (!int.TryParse(Console.ReadLine(), out input) || !IsValidInput(input))
            {
                LogError("Invalid input");
            }

            Console.Clear();

            switch (input)
            {
                case ConsoleKey.D0:
                    PromptAddStudent();
                    break;
                case 3:
                    ShowGrades();
                    break;
            }

            bool IsValidInput(int option) => option >= 0 && option <= 4;
        }

        private void PromptAddStudent()
        {
            Console.WriteLine("Enter the student's first name: ");
            Console.WriteLine("Enter the student's last name: ");
            Console.WriteLine("Enter the student's date of birth: ");
            Console.WriteLine("Enter the student's student number: ");

        }

        private void RemoveStudent()
        {
            Console.WriteLine("Enter the student number of the student you want to delete: ");
        }

        public void RemoveStudent(int studentNumber)
        {
            students.RemoveAll(student => studentNumber == student.StudentNumber);
        }

        private Student? GetStudent(int studentNumber) 
        {
            return students.Find(student => student.StudentNumber == studentNumber);
        }

        public void ShowGrades()
        {
            int studentNumber;
            while (!int.TryParse(Console.ReadLine(), out studentNumber))
            {
                LogError("Invalid input, please try again.");
            }

            Student? student = students.Find(student => student.StudentNumber == studentNumber);

            if (student is null)
            {
                LogError($"No student was found with the student number {studentNumber}");
            }
            else
            {
                student.PrintGrades();
            }
        }

        void LogError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
