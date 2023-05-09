using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Week01
{
    internal class Student
    {
        private string firstName;
        private string lastName;
        private readonly DateTime birthDate;
        private readonly int studentNumber;
        private readonly List<Grade> grades = new();

        public string FirstName => firstName;
        public string LastName => lastName;
        public string FullName => $"{firstName} {lastName}";
        public DateTime BirthDate => birthDate;
        public int StudentNumber => studentNumber;

        public Student(string firstName, string lastName, DateTime birthDate, int studentNumber)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.birthDate = birthDate;
            this.studentNumber = studentNumber;
        }

        public void SetGrade(int examCode, decimal value)
        {
            if (IsResit(examCode))
            {
                UpdateGrade(examCode, value);
            }
            else
            {
                grades.Add(new Grade(value, examCode));
            }
        }

        public void PrintGrades()
        {
            foreach (Grade grade in grades.OrderBy(grade => grade.Date))
            {
                Console.WriteLine(grade);
            }
        }

        public void PrintGrades(DateTime from, DateTime till)
        {
            Func<Grade, bool> isInPeriod = grade => grade.Date >= from && grade.Date <= till;

            foreach (Grade grade in grades.Where(isInPeriod).OrderBy(grade => grade.Date))
            {
                Console.WriteLine(grade);
            }
        }

        public List<Grade> GradesFor(int examCode)
        {
            return grades.Where(grade => grade.ExamCode == examCode).ToList();
        }

        public decimal GradePointAverage()
        {
            var examCodes = grades.Select(grade => grade.ExamCode).Distinct();
            var finalGrades = examCodes.Select(examCode => HighestGrade(examCode));
            return finalGrades.Average(grade => grade.Value);
        }

        public override string ToString() => $"{FullName} ({studentNumber})";

        private bool IsResit(int examCode)
        {
            return grades.Any(grade => grade.ExamCode == examCode && !grade.Frozen);
        }

        private void UpdateGrade(int examCode, decimal value)
        {
            Grade? grade = GradesFor(examCode).FirstOrDefault(grade => !grade.Frozen);

            if (grade is not null)
            {
                grade.Value = value;
            }
            else
            {
                throw new ArgumentException("Error: Couldn't update grade.");
            }
        }

        private Grade HighestGrade(int examCode)
        {
            return GradesFor(examCode).OrderBy(grade => grade.Value).First();
        }
    }
}
