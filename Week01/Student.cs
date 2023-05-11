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
        private IEnumerable<int> ExamCodes => from grade in grades select grade.ExamCode;
        private IEnumerable<Grade> FinalGrades => from examCode in ExamCodes select HighestGrade(examCode);

        public Student(string firstName, string lastName, DateTime birthDate, int studentNumber)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.birthDate = birthDate;
            this.studentNumber = studentNumber;
        }

        public void SetGrade(int examCode, decimal value)
        {
            Grade? grade = grades.Find(grade => grade.ExamCode == examCode && !grade.Frozen);

            if (grade is not null)
            {
                grade.Value = value; 
            }
            else
            {
                grades.Add(new Grade(value, examCode));
            }
        }

        public bool TrySetGrade(int examCode, decimal value)
        {
            try
            {
                SetGrade(examCode, value);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
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
            bool IsInPeriod(Grade grade) => grade.Date >= from && grade.Date <= till;

            foreach (Grade grade in grades.Where(IsInPeriod).OrderBy(grade => grade.Date))
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
            return FinalGrades.Average(grade => grade.Value);
        }

        public override string ToString() => $"{FullName} ({studentNumber})";
        
        private Grade HighestGrade(int examCode)
        {
            Grade? grade =  GradesFor(examCode).MaxBy(grade => grade.Value);

            if (grade is null)
            {
                throw new ArgumentException($"Couldn't find a grade with exam code {examCode}");
            }
            return grade;
        }
    }
}
