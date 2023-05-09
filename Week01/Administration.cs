using System;
using System.Collections.Generic;
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
            PromptMenu();
        }

        private void PromptMenu()
        {
            Console.WriteLine("Grade Administration System");
            Console.WriteLine("1) Add student.");
            Console.WriteLine("2) Remove student.");
            Console.WriteLine("3) Show student's grades.");
            Console.WriteLine("4) Exit.");

            int input;
            do
            {
                input = Convert.ToInt32(Console.ReadLine());
            }
            while (!IsValidInput(input));

            Console.Clear();

            switch (input)
            {
                case 1:
                    PromptAddStudent();
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

        private void PromprRemoveStudent()
        {
            Console.WriteLine("Enter the student number of the student you want to delete: ");

        }

        public void RemoveStudent(int studentNumber)
        {
            students.RemoveAll(student => studentNumber == student.StudentNumber);
        }

        public void PrintGrades(int studentNumber)
        {
            Student? student = students.Find(student => student.StudentNumber == studentNumber);
            student?.PrintGrades();
        }
    }
}
