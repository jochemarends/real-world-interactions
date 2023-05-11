using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Week01
{
    internal class Menu
    {
        private List<(string name, Action handler)> items = new();
        private string title;
        private bool shouldClose = false;

        public void AddItem(string name, Action handler) => items.Add((name, handler));
        
        public Menu(string title) => this.title = title;

        public void Run()
        {
            while (!shouldClose)
            {
                Write();
                int index = ReadInput() - 1;
                Console.Clear();
                items[index].handler();
                Console.Clear();
            }
        }

        public void Close() => shouldClose = true;

        int ReadInput()
        {
            ConsoleKeyInfo keyInfo;
            int input;

            do
            {
                keyInfo = Console.ReadKey(true);
            } 
            while (!int.TryParse(keyInfo.KeyChar.ToString(), out input) || !IsItem(input));

            return input;
        }

        private void Write()
        {
            Console.WriteLine(title);

            foreach(int number in Enumerable.Range(1, items.Count))
            {
                Console.WriteLine($"{number}. {items[number - 1].name}");
            }
        }

        private bool IsItem(int number) => number >= 1 && number <= items.Count;
    }

    internal class Administration
    {
        private readonly Menu menu = new("Grade Administration");
        private readonly List<Student> students = new();

        public Administration()
        {
            menu.AddItem("Add student.", AddStudent);
            menu.AddItem("Show students", ShowStudents);
            menu.AddItem("Show grades.", ShowGrades);
            menu.AddItem("Add grade.", AddGrade);
            menu.AddItem("Freeze grade.", FreezeGrade);
            menu.AddItem("Exit.", Exit);
        }

        public void Run() => menu.Run();

        private void AddStudent()
        {
            Console.Write("First name: ");
            string firstName = ReadString();

            Console.Write("Last name: ");
            string lastName = ReadString();

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
            foreach (Student student in students)
            {
                Console.WriteLine(student);
            }

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
                    WriteError($"No grade has {examCode} as exam code.");
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

        public void Exit() => menu.Close();

        private Student? FindStudent(int studentNumber)
        {
            return students.Find(student => student.StudentNumber == studentNumber);
        }

        private string ReadString()
        {
            string? input;
            while (string.IsNullOrEmpty(input = Console.ReadLine()))
            {
                WriteError("Invalid input. Please try again.");
            }
            return input;
        }

        private int ReadInt()
        {
            int input;
            while (!int.TryParse(Console.ReadLine(),out input))
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
            while (!DateTime.TryParseExact(ReadString(), format, null, DateTimeStyles.None, out input))
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
