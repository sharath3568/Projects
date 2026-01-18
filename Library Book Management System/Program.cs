using Library_Book_Management_System.Entities;
using Library_Book_Management_System.Interfaces;
using Library_Book_Management_System.Managers;
using Library_Book_Management_System.UI;
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
            IBookManager bookManager = new BookManager(size);

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

            while (true)
            {
                Console.WriteLine("\n1. Book Management\n2. Member Management\n3. Issue / Return Books\n4. View Active Issues\n5. Exit\n");
                Console.Write("Select Your Operation : ");

                if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > 5)
                {
                    Console.Write("Invalid Value! Please try again : ");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        BookManagement(choice, bookManager);
                        break;
                    case 2:
                        MemberManagement(choice, memberManager);
                        break;
                    case 3:
                        IssueReturnManagement(choice, issueManager, memberManager, bookManager);
                        break;
                    case 4:
                        ViewActiveIssues(issueManager);
                        break;
                    case 5:
                        Console.WriteLine("\nThank you for using Library Management System! Have a nice day......");
                        return;
                }
            }
        }

        public static void BookManagement(int choice, IBookManager bookManager)
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
                        return;
                }
            }
        }

        public static void MemberManagement(int choice, MemberManager memberManager)
        {
            while (true)
            {
                bool canAdd = memberManager.HasCapacity();
                int operation = CheckOperation(choice, canAdd);

                switch (operation)
                {
                    case 1:
                        MemberUI.AddMember(memberManager, false);
                        break;
                    case 2:
                        MemberUI.ViewAllMembers(memberManager);
                        break;
                    case 3:
                        MemberUI.ViewMemberByID(memberManager);
                        break;
                    case 4:
                        MemberUI.DeleteMember(memberManager);
                        break;
                    case 5:
                        Console.WriteLine("Returning to Main Menu");
                        return;
                }
            }
        }

        public static void IssueReturnManagement(int choice, IssueManager issueManager, MemberManager memberManager, IBookManager bookManager)
        {
            while (true)
            {
                bool canAdd = issueManager.HasCapacity();
                int operation = CheckOperation(choice, canAdd);

                switch (operation)
                {
                    case 1:
                        IssueUI.IssueBook(issueManager, memberManager);
                        break;
                    case 2:
                        IssueUI.ReturnBook(issueManager, memberManager, bookManager);
                        break;
                    case 3:
                        Console.WriteLine("Back to Main Menu");
                        return;
                }
            }
        }

        public static void ViewActiveIssues(IssueManager issueManager)
        {
            IssueUI.ViewActiveIssues(issueManager);

            Console.WriteLine("Going to Main Menu");
        }

        public static int CheckOperation(int choice, bool canAdd)
        {
            PrintMenu(choice, canAdd);

            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out int input))
                {
                    Console.Write("Invalid Input! Please try again : ");
                    continue;
                }

                // BOOK / MEMBER MANAGEMENT
                if (choice == 1 || choice == 2)
                {
                    if (!canAdd && input == 1)
                    {
                        Console.Write("Operation not allowed! Capacity full : ");
                        continue;
                    }

                    if (input >= 1 && input <= 5)
                        return input;
                }

                // ISSUE MANAGEMENT
                if (choice == 3)
                {
                    if (!canAdd && input == 1)
                    {
                        Console.Write("Cannot issue more books (Issue limit reached) : ");
                        continue;
                    }

                    if (input >= 1 && input <= 3)
                        return input;
                }

                Console.Write("Invalid Input! Please try again : ");
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
                        Console.WriteLine("\n1. Add Member");
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
    }
}
