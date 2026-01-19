using Library_Book_Management_System.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Book_Management_System.Interfaces
{
    public interface IBookLookup
    {
        Book FindBookByID(string bookID);
    }
}
