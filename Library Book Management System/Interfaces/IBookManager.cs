using Library_Book_Management_System.Entities;

namespace Library_Book_Management_System.Interfaces
{
    public interface IBookManager
    {
        bool HasCapacity();
        bool AddBook(Book book);
        Book ViewBookByID(string bookID);
        Book[] ViewBooks();
        bool DeleteBook(string bookID);
    }
}
