using Library_Book_Management_System.Entities;
using Library_Book_Management_System.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Library_Book_Management_System.UI.BookUI
{
    public class BookUI
    {
        public static BookManager BookMainLogic()
        {
            int size;
            // Get maximum number of books from user
            Console.Write("\nEnter the number of books you want to store : ");
            while (!int.TryParse(Console.ReadLine(), out size) || size <= 0)
            {
                Console.Write("Invalid Input! Please try again : ");
            }

            BookManager bookManager = new BookManager(size);
            return bookManager;
        }

        /// <summary>
        /// Displays available Book operations and validates user choice.
        /// </summary>
        public static int SelectBookOperation(bool hasCapacity)
        {
            if (hasCapacity)
            {
                Console.WriteLine("\n1.Add Book\n2.View Book List\n3.View Book by ID\n4.Issue Book\n5.Return Book\n6.Delete Book\n7.Exit");
            }
            else
            {
                Console.WriteLine("\n2.View Book List\n3.View Book by ID\n4.Issue Book\n5.Return Book\n6.Delete Book\n7.Exit");
            }
            int choice;
            Console.Write("Select the operation : ");

            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 7)
            {
                Console.Write("Invalid Input! Please try again : ");
            }
            return choice;
        }

        /// <summary>
        /// Asks user whether they want to continue.
        /// </summary>
        public static bool CheckRepeat()
        {
            Console.Write("Do you want to continue (Yes/No): ");
            while (true)
            {
                string input = Console.ReadLine();
                if (string.Equals(input, "Yes", StringComparison.OrdinalIgnoreCase))
                    return true;

                if (string.Equals(input, "No", StringComparison.OrdinalIgnoreCase))
                    return false;

                Console.Write("Invalid Input! Please try again : ");
            }
        }

        /// <summary>
        /// Validates text input (letters and spaces only).
        /// </summary>
        public static string CheckValid()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input) && Regex.IsMatch(input, @"^[A-Za-z ]+$"))
                    return input;

                Console.Write("Invalid Input! Please try again : ");
            }
        }

        /// <summary>
        /// Gets a valid Book ID from user.
        /// </summary>
        public static string CheckBookID()
        {
            Console.Write("Enter Book ID : ");
            while (true)
            {
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                    return input.ToUpper();

                Console.Write("Invalid Book ID! Please try again : ");
            }
        }

        /// <summary>
        /// Handles adding a new book.
        /// </summary>
        public static void AddBook(BookManager bookManager)
        {
            Console.Write("\nBook Title : ");
            string title = CheckValid();

            Console.Write("Book Author : ");
            string author = CheckValid();

            Category category = CheckCategory();

            Book book = new Book(title, author, category);

            if (bookManager.AddBook(book))
            {
                Console.WriteLine("\nBook added successfully.");
                Console.WriteLine($"Book ID : {book.BookID}\nStatus : Available");
            }
            else
                Console.WriteLine("\nFailed to add book.");
        }

        /// <summary>
        /// Displays details of a single book.
        /// </summary>
        public static void ViewBookByID(BookManager bookManager)
        {
            string bookID = CheckBookID();
            Book book = bookManager.ViewBookByID(bookID);

            if (book == null)
            {
                Console.Write($"Provided Book ID {bookID} is not Found!");
            }
            else
                Console.WriteLine($"ID: {book.BookID}\nTitle: {book.Title}\nAuthor: {book.Author}\nCategory: {book.Category}\nAvailable: {book.IsAvailable}");
        }

        /// <summary>
        /// Displays all books in the library.
        /// </summary>
        public static void ViewBookList(BookManager bookManager)
        {
            Book[] books = bookManager.ViewBooks();
            bool hasBooks = false;

            foreach (Book book in books)
            {
                if (book != null)
                {
                    hasBooks = true;
                    Console.WriteLine($"ID: {book.BookID}, Title: {book.Title}, Available: {book.IsAvailable}");
                }
            }

            if (!hasBooks)
                Console.WriteLine("No books available.");
        }

        public static void IssueBook(BookManager bookManager)
        {
            string bookID = CheckBookID();
            Console.WriteLine(bookManager.IssueBook(bookID)
                ? "Book issued successfully."
                : "Book not available.");
        }

        public static void ReturnBook(BookManager bookManager)
        {
            string bookID = CheckBookID();
            Console.WriteLine(bookManager.ReturnBook(bookID)
                ? "Book returned successfully."
                : "Book not found.");
        }

        public static void DeleteBook(BookManager bookManager)
        {
            string bookID = CheckBookID();
            Console.WriteLine(bookManager.DeleteBook(bookID)
                ? "Book deleted successfully."
                : "Book not found.");
        }

        /// <summary>
        /// Allows user to select a book category.
        /// </summary>
        public static Category CheckCategory()
        {
            Console.WriteLine("\n1.Fiction\n2.ScienceFiction\n3.Fantasy\n4.Mystery\n5.Thriller\n6.Romance\n7.Biograph\n8.History");
            Console.Write("\nSelect Category : ");

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= 8)
                    return (Category)(choice - 1);

                Console.Write("Invalid Input! Please try again : ");
            }
        }
    }
}
