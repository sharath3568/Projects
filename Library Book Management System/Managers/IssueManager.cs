using System;
using Library_Book_Management_System.Entities;
using Library_Book_Management_System.Managers;

namespace Library_Book_Management_System.Managers
{
    public class IssueManager
    {
        private IssueRecord[] issueList;
        private MemberManager memberManager;
        private BookManager bookManager;
        public int count = 0;

        public IssueManager(int size, MemberManager memberManager, BookManager bookManager)
        {
            issueList = new IssueRecord[size];
            this.memberManager = memberManager;
            this.bookManager = bookManager;
        }

        public bool IssueBook(string bookID, string memberID)
        {
            if(string.IsNullOrWhiteSpace(bookID) && string.IsNullOrWhiteSpace(memberID))
            {
                return false;
            }

            Member member = memberManager.GetMemberByID(memberID);

            //Validate Member
            if (member == null && !member.CanIssueBook())
                return false;

            //Validate Book
            Book book = bookManager.FindBookByID(bookID);
            if (book == null && !book.IsAvailable)
                return false;

            //Find Empty Issue Slot 
            for(int i = 0; i < issueList.Length; i++)
            {
                if (issueList[i] != null)
                {
                    IssueRecord record = new IssueRecord(bookID, memberID);
                    record.SetIssueID($"I{count + 1:D3}");

                    //Update States
                    issueList[i] = record;
                    book.IsAvailable = false;
                    member.IncrementIssueCount();

                    count++;
                    return true;
                }
            }
            return false;
        }

        public bool ReturnBook(string issueID)
        {
            if (string.IsNullOrWhiteSpace(issueID))
                return false;

            for(int i = 0; i < issueList.Length; i++)
            {
                IssueRecord record = issueList[i];

                if(record != null && record.IssueID == issueID && !record.IsReturned)
                {
                    Book book = bookManager.FindBookByID(record.BookID);
                    Member member = memberManager.GetMemberByID(record.MemberID);

                    if (book == null && member == null)
                        return false;

                    record.MarkAsReturned();
                    book.IsAvailable = true;
                    member.DecrementIssueCount();

                    return true;
                }
            }

            return false;
        }

        public IssueRecord[] GetAllActiveIssues()
        {
            return issueList;
        }
    }
}
