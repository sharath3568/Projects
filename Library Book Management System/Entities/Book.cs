using System;

namespace Library_Book_Management_System.Entities
{
    /// <summary>
    /// Represents a single book in the library.
    /// Holds book details and availability status.
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Unique identifier for the book (e.g., B001).
        /// Set internally by BookManager.
        /// </summary>
        public string? BookID { get; private set; }

        /// <summary>
        /// Title of the book.
        /// </summary>
        public string? Title { get; private set; }

        /// <summary>
        /// Author name of the book.
        /// </summary>
        public string? Author { get; private set; }

        /// <summary>
        /// Category/Genre of the book.
        /// </summary>
        public Category Category { get; private set; }

        /// <summary>
        /// Indicates whether the book is currently available for issue.
        /// </summary>
        public bool IsAvailable { get; set; }

        /// <summary>
        /// Constructor to create a new book.
        /// By default, a newly added book is available.
        /// </summary>
        /// <param name="title">Book title</param>
        /// <param name="author">Book author</param>
        /// <param name="category">Book category</param>
        public Book(string title, string author, Category category)
        {
            Title = title;
            Author = author;
            Category = category;
            IsAvailable = true;
        }

        /// <summary>
        /// Assigns a unique Book ID.
        /// Restricted to internal use to ensure controlled ID generation.
        /// </summary>
        /// <param name="bookID">Generated book ID</param>
        internal void SetBookID(string bookID)
        {
            BookID = bookID;
        }
    }

    /// <summary>
    /// Enumeration representing supported book categories.
    /// </summary>
    public enum Category
    {
        Fiction,
        ScienceFiction,
        Fantasy,
        Mystery,
        Thriller,
        Romance,
        Biograph,
        History
    }
}
