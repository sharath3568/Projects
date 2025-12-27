using System.ComponentModel.Design;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace Library_Book_Management_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = 0;
            bool hasCapacity = true;
            bool isRepeat = true;
            Console.Write("Enter the number of books you want to store : ");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out size) && size > 0)
                {
                    break;
                }
                else
                {
                    Console.Write("\nInvalid Input! Please try again : ");
                }
            }
            BookManager bookManager = new BookManager(size);
            while (isRepeat)
            {
                int operation = SelectOperation(hasCapacity);
                switch (operation)
                {
                    case 1:
                        hasCapacity = AddBook(bookManager);
                        break;
                    case 2:
                        ViewBookList(bookManager);
                        break;
                    case 3:
                        ViewBookByID(bookManager);
                        break;
                    case 4:
                        //IssueBook(bookManager);
                        break;
                    case 5:
                        //ReturnBook(bookManager);
                        break;
                    case 6:
                        //UpdateBook(bookManager);
                        break;
                    case 7:
                        //DeleteBook(bookManager);
                        break;
                    case 8:
                        Console.WriteLine("\nExiting Program............");
                        return;
                }
                isRepeat = CheckRepeat();
            }

        }

        public static int SelectOperation(bool hasCapacity)
        {
            if (hasCapacity)
            {
                Console.WriteLine("\n1.Add Book\n2.View Book List\n3.View Book by ID\n4.Issue Book\n5.Return Book\n6.Update Book\n7.Delete Book\n8.Exit");
            }
            else
            {
                Console.WriteLine("\n2.View Book List\n3.View Book by ID\n4.Issue Book\n5.Return Book\n6.Update Book\n7.Delete Book\n8.Exit");
            }
            Console.Write("\nSelect the Operation you want to perform : ");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int temp) && (temp > 0 && temp <= 7))
                {
                    return temp;
                }
                else
                {
                    Console.Write("\nInvalid Input! Please try again : ");
                }
            }
        }

        public static bool CheckRepeat()
        {
            Console.Write("\nDo you want to continue! Please provide Yes/No : ");
            while (true)
            {
                string? input = Console.ReadLine();
                if (string.Equals(input, "Yes", StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
                else if (string.Equals(input, "No", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("\nExiting Program.............");
                    return false;
                }
                else
                {
                    Console.Write("\nInvalid Input! Please try again : ");
                }
            }
        }

        public static string CheckValid()
        {
            while (true)
            {
                string? input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.Write("\nInput cannot be null or empty! Please try again : ");
                    continue;
                }

                if (Regex.IsMatch(input, @"^[A-za-z ]+$"))
                {
                    return input;
                }
                else
                {
                    Console.Write("\nInvalid Input! Please try again : ");
                }
            }
        }

        public static Category CheckCategory()
        {
            Console.WriteLine("\n1.Fiction\n2.ScienceFiction\n3.Fantasy\n4.Mystery\n5.Thriller\n6.Romance\n7.Biograph\n8.History\n");
            Console.Write("Select the Genre : ");
            while (true)
            {
                int category;
                if (int.TryParse(Console.ReadLine(), out category) && (category > 0 && category <= 8))
                {
                    switch (category)
                    {
                        case 1:
                            return Category.Fiction;
                        case 2:
                            return Category.ScienceFiction;
                        case 3:
                            return Category.Fantasy;
                        case 4:
                            return Category.Mystery;
                        case 5:
                            return Category.Thriller;
                        case 6:
                            return Category.Romance;
                        case 7:
                            return Category.Biograph;
                        case 8:
                            return Category.History;
                    }
                }
                else
                {
                    Console.Write("Invalid Input! Please try again : ");
                }
            }
        }

        public static string CheckBookID()
        {
            Console.Write("Enter Book ID : ");
            while (true)
            {
                string? bookID = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(bookID))
                {
                    return bookID;
                }
                else
                {
                    Console.Write("Invalid Student ID! Please try again : ");
                }
            }
        }

        public static bool AddBook(BookManager bookManager)
        {
            bool hasCapacity = bookManager.HasCapacity();

            if (hasCapacity)
            {
                Console.Write("\nBook Title : ");
                string? bookTitle = CheckValid();
                Console.Write("Book Author Name : ");
                string? bookAuthor = CheckValid();
                Category bookCategory = CheckCategory();

                Book book = new Book(bookTitle, bookAuthor, bookCategory, true);

                bool response = bookManager.AddBook(book);

                if (response)
                {
                    Console.Write("\nBook Added Successfully");
                }
                else
                {
                    Console.Write("Issue Adding the book! Please try again");
                }
                return true;
            }
            else
            {
                Console.WriteLine("\nAddition Limit Exceeded! Please try again");
                return false;
            }
        }

        public static void ViewBookByID(BookManager bookManager)
        {
            string? bookID = CheckBookID();
            Book book = bookManager.ViewBookByID(bookID);

            if (book == null)
            {
                Console.Write($"Provided Book ID {bookID} is not Found!");
            }
            else
            {
                Console.WriteLine($"\nBook ID : {book.BookID}\nTitle : {book.Title}\nAuthor : {book.Author}\nCategory : {book.Category}\nAvailable : {book.IsAvailable}");
            }
        }

        public static void ViewBookList(BookManager bookManager)
        {
            Book[] book = bookManager.ViewBooks();

            Console.WriteLine("Book Details : \n");
            for (int i = 0; i < book.Length; i++)
            {
                Console.WriteLine($"Book ID : {book[i].BookID}\nTitle : {book[i].Title}\nAuthor : {book[i].Author}\nCategory : {book[i].Category}\nAvailable : {book[i].IsAvailable}\n");
            }
        }
    }
}
