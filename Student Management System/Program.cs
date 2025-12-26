using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Student_Management_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            bool hasCapacity = true;
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
                int operation = SelectOperation(hasCapacity);
                switch (operation)
                {
                    case 1:
                        hasCapacity = AddStudent(student);
                        break;
                    case 2:
                        ViewStudent(student);
                        break;
                    case 3:
                        UpdateStudent(student);
                        break;
                    case 4:
                        DeleteStudent(student);
                        break;
                    case 5:
                        Console.WriteLine("\nExiting Program................");
                        return;
                }
                isRepeat = CheckRepeat();
            }
        }

        public static int SelectOperation(bool hasCapacity)
        {
            if (hasCapacity)
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

        public static string CheckStudentID()
        {
            Console.Write("Enter Student ID : ");
            while (true)
            {
                string studentID = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(studentID))
                {
                    return studentID;
                }
                else
                {
                    Console.Write("Invalid Student ID! Please try again : ");
                }
            }
        }

        public static void ViewStudentDetails(StudentManager student,string studentID)
        {

            Student studentDetails = student.ViewStudent(studentID);

            if (studentDetails == null)
            {
                Console.WriteLine("\nNo matching student found");
                return;
            }

            Console.WriteLine($"\nStudent ID : {studentDetails.StudentID}\nStudent Name : {studentDetails.Name}\nStudent Age : {studentDetails.Age}\nStudent Marks : {studentDetails.Marks}");
        }

        public static bool AddStudent(StudentManager student)
        {

            bool hasCapacity = student.HasCapacity();
            if (hasCapacity)
            {
                Console.WriteLine("\nEnter the details\n");

                Console.Write("Student Name : ");
                string studentName = CheckValid<string>();

                Console.Write("Student Age : ");
                int studentAge = CheckValid<int>();

                Console.Write("Enter Gender 'Male', 'Female', 'Others' : ");
                Gender studentGender = GetGender();

                Console.Write("Student Marks : ");
                float studentMarks = CheckValid<float>();

                Student studentDetails = new Student(studentName, studentAge, studentGender, studentMarks);
                bool response = student.AddStudent(studentDetails);

                if (response)
                {
                    Console.WriteLine($"\nStudent Details added successfully with student ID : {studentDetails.StudentID}");
                }
                else
                {
                    Console.WriteLine("Student details did not added! Please try again");
                }
                return hasCapacity;
            }
            else 
            {
                Console.WriteLine("\nAddition of the students limit exceeded!");
                return hasCapacity;
            }
        }

        public static void ViewStudent(StudentManager student)
        {
            string studentID = CheckStudentID();
            ViewStudentDetails(student, studentID);
        }

        public static void UpdateStudent(StudentManager student)
        {
            string studentID = CheckStudentID();
            Console.Write("\nEnter Updated Student Name : ");
            string studentName = CheckValid<string>();
            Console.Write("Enter Updated Student Age : ");
            int studentAge = CheckValid<int>();
            Console.Write("Enter Updated Student Marks : ");
            float studentMarks = CheckValid<float>();
            Console.Write("Enter Updated Student Gender : ");
            Gender studentGender = GetGender();
            bool isUpdated = student.UpdateStudent(studentID,studentName, studentAge, studentMarks, studentGender);

            if (isUpdated)
            {
                Console.WriteLine("\nUpdated Student Details Successfully");
                ViewStudentDetails(student, studentID);
            }
            else
            {
                Console.WriteLine("\nStudent Details not updated! Please try again");
            }
        }

        public static void DeleteStudent(StudentManager student)
        {
            string studentID = CheckStudentID();

            bool isDeleted = student.DeleteStudent(studentID);

            if (isDeleted)
            {
                Console.WriteLine($"Student ID : {studentID.ToUpper()} Deleted Successfully...");
            }
            else
            {
                Console.WriteLine($"Student ID : {studentID} is not found");
            }
        }
    }
}
