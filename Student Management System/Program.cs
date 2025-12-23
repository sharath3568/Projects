namespace Student_Management_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the Count of the students data : ");
            while (true)
            {
                if(int.TryParse(Console.ReadLine(), out int count) && count > 0)
                {
                    StudentManager student = new StudentManager(count);
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Value! Please try again");

                }
            }
        }
    }
}
