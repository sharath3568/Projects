using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Student_Management_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            bool isLimitExceeded = false;
            bool isRepeat = true;
            Console.Write("Enter the Count of the students data : ");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out count) && count > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid! Please provide the value greater than 0");
                }
            }
            StudentManager student = new StudentManager(count);
            while (isRepeat)
            {
                int operation = SelectOperation(isLimitExceeded);
                switch (operation)
                {
                    case 1:
                        isLimitExceeded = AddStudent(student);
                        break;
                    case 2:
                        ViewStudent(student);
                        break;
                    case 3:
                        //UpdateStudent();
                        break;
                    case 4:
                        //DeleteStudent();
                        break;
                    case 5:
                        Console.WriteLine("\nExiting Program................");
                        return;
                }
                isRepeat = CheckRepeat();
            }
        }

        public static int SelectOperation(bool isLimitExceeded)
        {
            if (isLimitExceeded)
            {
                Console.WriteLine("\n1.Add New Student\n2.View Student details\n3.Update Student details\n4.Delete Student\n5.Exit\n");
            }
            else
            {
                Console.WriteLine("\n2:View Student details\n3.Update Student details\n4.Delete Student Details\n5.Exit\n");
            }

            Console.Write("Select the Operation you want to perform : ");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int temp) && (temp > 0 && temp <= 5))
                {
                    return temp;
                }
                else
                {
                    Console.Write("Invalid Option selected! Please try again : ");
                }
            }
        }

        public static T CheckValid<T>()
        {
            string? input;
            while (true)
            {
                if (typeof(T) == typeof(string))
                {
                    input = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine("Input cannot be empty! Please try again");
                        continue;
                    }

                    if (Regex.IsMatch(input, @"^[A-za-z ]+$"))
                    {
                        return (T)(object)input;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input! Please try again");
                    }

                }
                else if (typeof(T) == typeof(int))
                {
                    if (int.TryParse(Console.ReadLine(), out int temp) && temp > 0)
                    {
                        return (T)(object)temp;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input! Please try again");
                    }
                }
                else if (typeof(T) == typeof(float))
                {
                    if (float.TryParse(Console.ReadLine(), out float temp))
                    {
                        return (T)(Object)temp;
                    }
                }
            }
        }

        public static Gender GetGender()
        {
            while (true)
            {
                string? input = Console.ReadLine();
                if (string.Equals(input, "male", StringComparison.OrdinalIgnoreCase) || string.Equals(input, "female", StringComparison.OrdinalIgnoreCase) || string.Equals(input, "others", StringComparison.OrdinalIgnoreCase))
                {
                    if (Enum.TryParse(input, true, out Gender gender))
                    {
                        return gender;
                    }
                }
                else
                {
                    Console.Write("Invalid Value! Please try again : ");
                }
            }
        }

        public static bool CheckRepeat()
        {
            Console.Write("\nDo you want to continue? Please input Yes/No : ");
            while (true)
            {
                string? input = Console.ReadLine();
                if (string.Equals(input, "Yes", StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
                else if (string.Equals(input, "No", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("\nExiting Program...................");
                    return false;
                }
                else
                {
                    Console.Write("Invalid Input! Please try again : ");
                }
            }
        }

        public static bool AddStudent(StudentManager student)
        {

            bool response = student.HasCapacity();
            if (response)
            {
                Console.WriteLine("\nEnter the details\n");
                Guid studentID = Guid.NewGuid();

                Console.Write("Student Name : ");
                string studentName = CheckValid<string>();

                Console.Write("Student Age : ");
                int studentAge = CheckValid<int>();

                Console.Write("Enter Gender 'Male', 'Female', 'Others' : ");
                Gender studentGender = GetGender();

                Console.Write("Student Marks : ");
                float studentMarks = CheckValid<float>();

                Student studentDetails = new Student(studentID, studentName, studentAge, studentGender, studentMarks);
                response = student.AddStudent(studentDetails);
            }
            else 
            {
                Console.WriteLine("\nAddition of the students limit exceeded!");
                return response;
            }
            return response;
        }

        public static void ViewStudent(StudentManager student)
        {
            Console.Write("Enter student name : ");
            string studentName = CheckValid<string>();
            Console.Write("Enter student age : ");
            int studentAge = CheckValid<int>();

            Student[] studentDetails = student.ViewStudent(studentName, studentAge);

            bool found = false;
            foreach(var studentList in studentDetails)
            {
                if (studentList == null) continue;

                found = true;

                Console.WriteLine($"Student ID : {studentList.StudentID}\nStudent Name : {studentList.Name}\nStudent Age : {studentList.Age}\nStudent Marks : {studentList.Marks}");
                Console.WriteLine("\n");
            }

            if (!found)
            {
                Console.WriteLine("No matching student found");
            }
        }
    }
}
