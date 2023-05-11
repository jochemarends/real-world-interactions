using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Week01
{
    internal class Administration
    {
        private readonly Menu menu = new("Grade Administration");
        private readonly List<Student> students = new();

        public Administration()
        {
            menu.AddItem("Add student.", AddStudent);
            menu.AddItem("Add grade.", AddGrade);
            menu.AddItem("Show students.", ShowStudents);
            menu.AddItem("Show grades.", ShowGrades);
            menu.AddItem("Freeze grade.", FreezeGrade);
            menu.AddItem("Exit.", Exit);
        }

        public void Run() => menu.Run();

        private void AddStudent()
        {
            Console.Write("First name: ");
            string firstName = ReadName();

            Console.Write("Last name: ");
            string lastName = ReadName();

            Console.Write("Date of birth (DD-MM-YYYY): ");
            DateTime birthDate = ReadDate();

            Console.Write("Student number: ");
            int studentNumber = ReadInt();

            if (FindStudent(studentNumber) is null)
            {
                students.Add(new Student(firstName, lastName, birthDate, studentNumber));
                WriteInfo("The student was successfully added.");
            }
            else
            {
                WriteError($"Student with {studentNumber} as student number already exists.");
                WriteError("The student was not added.");
            }

            WaitForKeyPress();
        }

        private void ShowGrades()
        {
            Console.Write("Student number: ");
            int studentNumber = ReadInt();

            Student? student = FindStudent(studentNumber);
            if (student is not null)
            {
                student.PrintGrades();
            }
            else
            {
                WriteError($"No student has {studentNumber} as student number.");
            }

            WaitForKeyPress();
        }

        private void ShowStudents()
        {
            students.ForEach(Console.WriteLine);
            WaitForKeyPress();
        }

        private void AddGrade()
        {
            Console.Write("Student number: ");
            int studentNumber = ReadInt();

            Student? student = FindStudent(studentNumber);
            if (student is not null)
            {
                Console.Write("Exam code: ");
                int examCode = ReadInt();

                Console.Write("Grade value: ");
                while (!student.TrySetGrade(examCode, ReadDecimal()))
                {
                    WriteError("Invalid input. Please try again.");
                    WriteInfo("A grade value must lay within the range of [1-10] and be a multiple of 0,5");
                }
            }
            else
            {
                WriteError($"No student has {studentNumber} as student number.");
            }

            WaitForKeyPress();
        }

        private void FreezeGrade()
        {
            Console.Write("Student number: ");
            int studentNumber = ReadInt();

            Student? student = FindStudent(studentNumber);
            if (student is not null)
            {
                Console.Write("Exam code: ");
                int examCode = ReadInt();

                List<Grade> grades = student.GradesFor(examCode);
                if (!grades.Any())
                {
                    WriteError($"No grade of {student.FullName} has {examCode} as exam code.");
                }

                foreach (Grade grade in grades)
                {
                    grade.Frozen = true;
                }
            }
            else
            {
                WriteError($"No student has {studentNumber} as student number.");
            }

            WaitForKeyPress();
        }

        private void Exit() => menu.Close();

        private Student? FindStudent(int studentNumber)
        {
            return students.Find(student => student.StudentNumber == studentNumber);
        }

        private string ReadName()
        {
            string? input;
            while (string.IsNullOrEmpty(input = Console.ReadLine()) || !input.All(char.IsLetter))
            {
                WriteError("Invalid input. Please try again.");
            }
            return input;
        }

        private int ReadInt()
        {
            int input;
            while (!int.TryParse(Console.ReadLine(), out input))
            {
                WriteError("Invalid input. Please try again.");
            }
            return input;
        }

        private decimal ReadDecimal()
        {
            decimal input;
            while (!decimal.TryParse(Console.ReadLine(), out input))
            {
                WriteError("Invalid input. Please try again.");
            }
            return input;
        }

        private DateTime ReadDate()
        {
            DateTime input;
            const string format = "dd-MM-yyyy";
            while (!DateTime.TryParseExact(Console.ReadLine(), format, null, DateTimeStyles.None, out input))
            {
                WriteError("Invalid input. Please try again.");
            }
            return input;
        }

        private void WaitForKeyPress()
        {
            WriteInfo("Press any key to continue.");
            Console.ReadKey(true);
        }

        private void WriteError(string message) => WriteColor(message, ConsoleColor.Red);
        private void WriteInfo(string message) => WriteColor(message, ConsoleColor.Yellow);
        private void WriteColor(string message, ConsoleColor color)
        {
            (color, Console.ForegroundColor) = (Console.ForegroundColor, color);
            Console.WriteLine(message);
            Console.ForegroundColor = color;
        }
    }
}
