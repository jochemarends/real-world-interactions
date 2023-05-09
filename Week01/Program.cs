namespace Week01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Student student = new Student("Jochem", "Arends", DateTime.Now, 495637);
            student.SetGrade(0, 7);
            student.SetGrade(1, 5);
            student.SetGrade(0, 2);
            Administration administration = new();
            administration.Run();
        }
    }
}