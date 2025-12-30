using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Book_Management_System.Entities
{
    public class Book
    {
        public string? BookID { get; private set; }
        public string? Title { get; private set; }
        public string? Author { get; private set; }
        public Category Category { get; private set; }
        public bool IsAvailable { get; set; }

        public Book(string title, string author, Category category)
        {
            Title = title;
            Author = author;
            Category = category;
            IsAvailable = true;
        }

        internal void SetBookID(string bookID)
        {
            BookID = bookID;
        }
    }

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
