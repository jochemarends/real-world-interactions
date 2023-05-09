using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week01
{
    internal class Grade
    {
        private decimal value;
        private bool frozen = false;
        private readonly DateTime date;
        private readonly int examCode;
        private readonly string note;

        public decimal Value
        {
            get => value;

            set
            {
                if (Frozen)
                {
                    throw new Exception("Error: Can't modify a frozen grade.");
                }

                if (!IsValidValue(value))
                {
                    throw new ArgumentException("Error: Invalid grade value.");
                }
                this.value = value;
            }
        }

        public bool Frozen
        {
            get => frozen;

            set
            {
                if (frozen && value == false)
                {
                    throw new ArgumentException("Error: Can't unfreeze grade.");
                }
                this.frozen = value;
            }
        }

        public DateTime Date => date;
        public int ExamCode => examCode;
        public string Note => note;

        public Grade(decimal value, DateTime date, int examCode, string note = "")
        {
            Value = value;
            this.date = date;
            this.examCode = examCode;
            this.note = note;
        }

        public Grade(decimal value, int examCode, string note = "") : this(value, DateTime.Now, examCode, note) 
        { 
        }

        public override string ToString() => $"{examCode} on {date}: {value}";

        private bool IsValidValue(decimal value)
        {
            const decimal minValue = 1.0m;
            const decimal maxValue = 10.0m;
            
            if (value >= minValue && value <= maxValue)
            {
                return IsMultipleOf(value, 0.5m);
            }
            return false;

            bool IsMultipleOf(decimal value, decimal factor) => value % factor == 0;
        }
    }
}
