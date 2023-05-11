namespace Week01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student("Jochem", "Arends", DateTime.Now, 495637);
            student.SetGrade(0, 7);
            student.SetGrade(1, 5);
            student.SetGrade(0, 2);

            Administration administration = new();
            administration.Run();

            //DateTime date = ReadDate();
        }

        static DateTime ReadDate()
        {
            DateTime input;
            while (!DateTime.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Invalid input. Please try again.");
            }
            return input;
        }
    }
}