using Library_Book_Management_System.Entities;
using System.Linq;

namespace Library_Book_Management_System.Managers
{
    /// <summary>
    /// Manages all book-related operations such as
    /// add, search, issue, return, and delete.
    /// </summary>
    public class BookManager
    {
        /// <summary>
        /// Fixed-size collection of books.
        /// </summary>
        private Book[] bookList;

        /// <summary>
        /// Keeps track of total books added (used for BookID generation).
        /// </summary>
        private int count = 0;

        /// <summary>
        /// Initializes the book manager with a fixed capacity.
        /// </summary>
        /// <param name="size">Maximum number of books</param>
        public BookManager(int size)
        {
            bookList = new Book[size];
        }

        /// <summary>
        /// Finds a book using its Book ID.
        /// </summary>
        /// <param name="bookID">Book ID to search</param>
        /// <returns>Book if found, otherwise null</returns>
        public Book FindBookByID(string bookID)
        {
            bookID = bookID.ToUpper();

            for (int i = 0; i < bookList.Length; i++)
            {
                if (bookList[i] != null && bookList[i].BookID == bookID)
                {
                    return bookList[i];
                }
            }
            return null;
        }

        /// <summary>
        /// Adds a new book to the first available slot.
        /// Generates a unique Book ID.
        /// </summary>
        /// <param name="book">Book object</param>
        /// <returns>True if added successfully, else false</returns>
        public bool AddBook(Book book)
        {
            for (int i = 0; i < bookList.Length; i++)
            {
                if (bookList[i] == null)
                {
                    book.SetBookID($"B{count + 1:D3}");
                    bookList[i] = book;
                    count++;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Returns the entire book list.
        /// </summary>
        public Book[] ViewBooks()
        {
            return bookList;
        }

        /// <summary>
        /// Returns a single book by ID.
        /// </summary>
        public Book ViewBookByID(string bookID)
        {
            return FindBookByID(bookID);
        }

        /// <summary>
        /// Checks whether there is space to add more books.
        /// </summary>
        public bool HasCapacity()
        {
            return bookList.Contains(null);
        }

        /// <summary>
        /// Issues a book if it exists and is available.
        /// </summary>
        public bool IssueBook(string bookID)
        {
            Book book = FindBookByID(bookID);

            if (book == null || !book.IsAvailable)
            {
                return false;
            }

            book.IsAvailable = false;
            return true;
        }

        /// <summary>
        /// Marks a book as returned.
        /// </summary>
        public bool ReturnBook(string bookID)
        {
            Book book = FindBookByID(bookID);

            if (book == null)
            {
                return false;
            }

            book.IsAvailable = true;
            return true;
        }

        /// <summary>
        /// Deletes a book by ID.
        /// </summary>
        public bool DeleteBook(string bookID)
        {
            for (int i = 0; i < bookList.Length; i++)
            {
                if (bookList[i] != null && bookList[i].BookID == bookID)
                {
                    bookList[i] = null;
                    return true;
                }
            }
            return false;
        }
    }
}
