using Library_Book_Management_System.Entities;
using Library_Book_Management_System.Interfaces;
using Library_Book_Management_System.Managers;
using Library_Book_Management_System.UI.Helper;

namespace Library_Book_Management_System.UI
{
    public class BookUI
    {
        public static void AddBook(IBookManager bookManager)
        {
            while (true)
            {
                bool hasCapacity = bookManager.HasCapacity();
                if (!hasCapacity)
                {
                    Console.WriteLine("\nLibrary Full Returning to Book Menu");
                    return;
                }

                Console.Write("\nBook Title : ");
                string title = HelperUI.CheckValidString();

                Console.Write("Book Author : ");
                string author = HelperUI.CheckValidString();

                Category category = CheckCategory();

                Book book = new Book(title, author, category);

                if (bookManager.AddBook(book))
                {
                    Console.WriteLine("\nBook added successfully.\n");
                    Console.WriteLine($"Book ID : {book.BookID}\nStatus : Available");
                }
                else
                {
                    Console.WriteLine("\nFailed to add book.");
                    return;
                }

                if (!HelperUI.CheckRepeat("BookManagement"))
                {
                    return;
                }
            }
        }

        public static void ViewBookByID(IBookManager bookManager)
        {
            string bookID = HelperUI.CheckID("Book");
            Book book = bookManager.ViewBookByID(bookID);

            if (book == null)
            {
                Console.Write($"Provided Book ID {bookID} is not Found!");
            }
            else
            {
                Console.WriteLine($"{"Book ID",-8} | {"Title",-35} | {"Author",-20} | {"Category",-15} | {"Status",-10}");
                Console.WriteLine(new string('-', 85));
                Console.WriteLine($"{ book.BookID, -8} | {book.Title, -35} | {book.Author, -20} | {book.Category, -15} | { (book.IsAvailable ? "Available" : "Issued"), -10}");
            }
        }

        public static void ViewBookList(IBookManager bookManager)
        {
            Book[] books = bookManager.ViewBooks();
            bool hasBooks = false;
            Console.WriteLine();
            Console.WriteLine($"{ "Book ID", -8} | { "Title", -35} | {"Author", -20} | {"Category", -15} | {"Status", -10}");
            Console.WriteLine(new string('-',95));
            foreach (Book book in books)
            {
                if (book == null)
                    continue;

                hasBooks = true;

                Console.Write($"{ book.BookID, -8} | { book.Title, -35} | { book.Author, -20} | { book.Category, -15} | ");

                if (book.IsAvailable)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{ "Available", -10}");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{ "Issued", -10}");
                }

                Console.ResetColor();
            }

            if (!hasBooks)
                Console.WriteLine("No books available.");

            Console.WriteLine();
        }

        public static void DeleteBook(IBookManager bookManager)
        {
            string bookID = HelperUI.CheckID("Book");
            Console.WriteLine(bookManager.DeleteBook(bookID)
                ? "Book deleted successfully."
                : "Book not found.");
        }

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
