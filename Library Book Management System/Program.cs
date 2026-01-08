using Library_Book_Management_System.Entities;
using Library_Book_Management_System.Managers;
using Library_Book_Management_System.UI.BookUI;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace Library_Book_Management_System
{
    /// <summary>
    /// Entry point of the Library Book Management System.
    /// Handles user interaction and input validation.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isRepeat = true;
            bool returntoMenu = false;
            Console.WriteLine("==================================");
            Console.WriteLine(" Library Management System ");
            Console.WriteLine("==================================");
            Console.WriteLine("Admin Console\n");

            while (isRepeat)
            {
                Console.WriteLine("1. Book Management\n2. Member Management\n3. Issue / Return Books\n4. View Active Issues\n5. Exit\n");
                Console.Write("Select Your Operation : ");
                if (int.TryParse(Console.ReadLine(), out int choice) && (choice > 1 || choice < 5))
                {
                    switch (choice)
                    {
                        case 1:
                            returntoMenu = BookManagement(choice);
                            break;
                        case 2:
                            returntoMenu = MemberManagement(choice);
                            break;
                        case 3:
                            returntoMenu = IssueReturnManagement(choice);
                            break;
                        case 4:
                            ViewActiveIssues();
                            break;
                        case 5:
                            Console.WriteLine("\nThank you for using Library Management System! Have a nice day......");
                            return;
                    }
                }
                else
                {
                    Console.Write("Invalid Value! Please try again : ");
                }
                if(!returntoMenu)
                    isRepeat = CheckRepeat();
            }
        }

        public static bool BookManagement(int choice)
        {
            BookManager bookManager = BookUI.BookMainLogic();
            int operation = CheckOperation(choice);

            switch (operation)
            {
                case 1:
                    BookUI.AddBook(bookManager);
                    break;
                case 2:
                    BookUI.ViewBookList(bookManager);
                    break;
                case 3:
                    BookUI.ViewBookByID(bookManager);
                    break;
                case 4:
                    BookUI.DeleteBook(bookManager);
                    break;
                case 5:
                    Console.WriteLine("\nGoing to Main Menu.....\n");
                    return true;
            }
            return false;
        }

        public static bool MemberManagement(int choice)
        {
            int operation = CheckOperation(choice);
            return false;
        }

        public static bool IssueReturnManagement(int choice)
        {
            int operation = CheckOperation(choice);
            return false;
        }

        public static void ViewActiveIssues()
        {

        }

        public static int CheckOperation(int choice)
        {
            while (true)
            {
                if(choice == 1)
                    Console.Write("\n1. Add Book\n2. View All Books\n3. View Book By ID\n4. Delete Book\n5. Back\n");
                if(choice == 2)
                    Console.WriteLine("\n1. Add Member\n2. View All Members\n3. View Member By ID\n4. Delete Member\n5. Back\n");
                if(choice == 3)
                    Console.WriteLine("\n1. Issue Book\n2. Return Book\n3. Back\n");

                Console.Write("\nSelect the Operation : ");

                if(int.TryParse(Console.ReadLine(), out int temp))
                {
                    if((choice == 1 || choice == 2) && (temp >= 1 || temp <= 5))
                        return temp;
                    if (choice == 3 && (temp >= 1 || temp <= 3))
                        return temp;

                    Console.Write("Invalid Input! Please try again : ");
                }
            }
        }

        public static bool CheckRepeat()
        {
            Console.Write("\nDo you want to repeat the operation? Yes/No : ");
            while (true)
            {
                string? input = Console.ReadLine();
                if (string.Equals(input, "Yes", StringComparison.OrdinalIgnoreCase))
                    return true;
                if (string.Equals(input, "No", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("\nThank you for using Library Management System! Have a nice day......");
                    return false;
                }

                Console.Write("Invalid Input! Please try again : ");
            }
        }

    }
}
