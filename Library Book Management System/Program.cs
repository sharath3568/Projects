using Library_Book_Management_System.Entities;
using Library_Book_Management_System.Managers;
using Library_Book_Management_System.UI.BookUI;
using Library_Book_Management_System.UI.MemberUI;
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
            int size;
            bool isRepeat = true;
            bool returntoMenu = false;
            Console.WriteLine("==================================");
            Console.WriteLine(" Library Management System ");
            Console.WriteLine("==================================");
            Console.WriteLine("Admin Console\n");

            // Get maximum Number of books from user
            Console.Write("\nEnter the Maximum Number of Books you want to store : ");
            while (!int.TryParse(Console.ReadLine(), out size) || size <= 0)
            {
                Console.Write("Invalid Input! Please try again : ");
            }
            //Initializing Book Manager
            BookManager bookManager = new BookManager(size);

            // Get Maximum number of members from user
            Console.Write("\nEnter the Maximum Number of Members you want to store : ");
            while (!int.TryParse(Console.ReadLine(), out size) || size <= 0)
            {
                Console.Write("Invalid Input! Please try again : ");
            }
            //Initializing Member Manager
            MemberManager memberManager = new MemberManager(size);

            // Get Maximum number of issues from user
            Console.Write("\nEnter the Maximum Number of Issues you want to give : ");
            while (!int.TryParse(Console.ReadLine(), out size) || size <= 0)
            {
                Console.Write("Invalid Input! Please try again : ");
            }
            //Initializing Issue Manager
            IssueManager issueManager = new IssueManager(size, memberManager, bookManager);

            while (isRepeat)
            {
                Console.WriteLine("\n1. Book Management\n2. Member Management\n3. Issue / Return Books\n4. View Active Issues\n5. Exit\n");
                Console.Write("Select Your Operation : ");
                if (int.TryParse(Console.ReadLine(), out int choice) && (choice >= 1 && choice <= 5))
                {
                    switch (choice)
                    {
                        case 1:
                            returntoMenu = BookManagement(choice, bookManager);
                            break;
                        case 2:
                            returntoMenu = MemberManagement(choice, memberManager);
                            break;
                        case 3:
                            returntoMenu = IssueReturnManagement(choice, issueManager);
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
                if (!returntoMenu)
                    isRepeat = CheckRepeat();
            }
        }

        public static bool BookManagement(int choice, BookManager bookManager)
        {
            while (true)
            {
                bool canAdd = bookManager.HasCapacity();
                int operation = CheckOperation(choice, canAdd);

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
            }
        }

        public static bool MemberManagement(int choice, MemberManager memberManager)
        {
            while (true)
            {
                bool canAdd = memberManager.HasCapacity();
                int operation = CheckOperation(choice, canAdd);

                switch (operation)
                {
                    case 1:
                        //MemberUI.AddMember(memberManager);
                        break;
                    case 2:
                        //MemberUI.ViewAllMembers(memberManager);
                        break;
                    case 3:
                        //.ViewMemberByID(memberManager);
                        break;
                    case 4:
                        //MemberUI.DeleteMember(memberManager);
                        break;
                    case 5:
                        Console.WriteLine("Returning to Main Menu");
                        return true;
                }
            }
        }

        public static bool IssueReturnManagement(int choice, IssueManager issueManager)
        {
            bool canAdd = true;
            int operation = CheckOperation(choice, canAdd);
            return false;
        }

        public static void ViewActiveIssues()
        {

        }

        public static int CheckOperation(int choice, bool canAdd)
        {
            PrintMenu(choice, canAdd);
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int temp))
                {
                    if ((choice == 1 && !canAdd) && temp == 1)
                    {
                        Console.WriteLine("\nInvalid Input! Please try again");
                        continue;
                    }
                    else if ((choice == 1 || choice == 2) && (temp >= 1 && temp <= 5))
                        return temp;
                    if (choice == 3 && (temp >= 1 && temp <= 3))
                        return temp;

                    Console.Write("Invalid Input! Please try again : ");
                }
            }
        }

        public static void PrintMenu(int choice, bool canAdd)
        {
            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    if (canAdd)
                        Console.WriteLine("\n1. Add Book");
                    Console.Write("2. View All Books\n3. View Book By ID\n4. Delete Book\n5. Back\n");
                    break;

                case 2:
                    if (canAdd)
                        Console.WriteLine("\n1.Add Member");
                    Console.WriteLine("2. View All Members\n3. View Member By ID\n4. Delete Member\n5. Back\n");
                    break;

                case 3:
                    if (canAdd)
                        Console.WriteLine("\n1. Issue Book");
                    Console.WriteLine("2. Return Book\n3. Back\n");
                    break;
            }
            Console.Write("\nSelect the Operation : ");
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
