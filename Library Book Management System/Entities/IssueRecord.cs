using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Book_Management_System.Entities
{
    public class IssueRecord
    {
        public string? IssueID { get; private set; }
        public string? BookID { get; private set; }
        public string? MemberID { get; private set; }
        public DateTime IssueDate { get; private set; }
        public DateTime? ReturnDate { get; private set; }
        public bool IsReturned { get; private set; }

        public IssueRecord(string bookID, string memberID)
        {
            BookID = bookID;
            MemberID = memberID;
            IssueDate = DateTime.Now;
            ReturnDate = null;
            IsReturned = false;
        }

        internal void SetIssueID(string issueID)
        {
            IssueID = issueID;
        }

        public void MarkAsReturned()
        {
            if (IsReturned)
                throw new InvalidOperationException("Book already returned.");

            IsReturned = true;
            ReturnDate = DateTime.Now;
        }

    }
}
