using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Book_Management_System.Entities
{
    public class Member
    {
        public string? MemberID { get; private set; }
        public string? Name { get; private set; }
        public int MaxAllowedBooks { get; private set; }
        public int CurrentIssuedCount { get; private set; }
        public Member (string name, int maxallowedbooks)
        {
            Name = name;
            MaxAllowedBooks = maxallowedbooks;
        }

        internal void setMemberID(string memberID)
        {
            MemberID = memberID;
        }

        public bool CanIssueBook()
        {
            return CurrentIssuedCount < MaxAllowedBooks;
        }

        public void IncrementIssueCount()
        {
            if (!CanIssueBook())
            {
                throw new InvalidOperationException("Member has reached the maximum allowed issued books,");
            }
            CurrentIssuedCount++;
        }

        public void DecrementIssueCount()
        {
            if(CurrentIssuedCount <= 0)
            {
                throw new InvalidOperationException("No issued books to return");
            }
            CurrentIssuedCount--;
        }
    }
}
