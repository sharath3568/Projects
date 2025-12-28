using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Book_Management_System
{
    public class BookManager
    {
        private Book[] bookList;
        int count = 0;
        public BookManager(int size)
        {
            bookList = new Book[size];
        }

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

        public Book[] ViewBooks()
        {
            return bookList;
        }

        public Book ViewBookByID(string bookID)
        {
            return FindBookByID(bookID);
        }

        public bool HasCapacity()
        {
            return bookList.Contains(null);
        }

        public bool IssueBook(string bookID)
        {
            bookID = bookID.ToUpper();
            Book book = FindBookByID(bookID);
            if (book == null)
            {
                return false;
            }
            else if (book.IsAvailable == false)
            {
                return false;
            }
            else
            {
                book.IsAvailable = false;
                return true;
            }
        }

        public bool ReturnBook(string bookID)
        {
            bookID = bookID.ToUpper();
            Book book = FindBookByID(bookID);
            if (book == null)
            {
                return false;
            }
            else
            {
                book.IsAvailable = true;
                return true;
            }
        }

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
