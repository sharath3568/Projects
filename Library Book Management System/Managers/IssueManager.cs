using System;
using Library_Book_Management_System.Entities;
using Library_Book_Management_System.Interfaces;
using Library_Book_Management_System.Managers;

namespace Library_Book_Management_System.Managers
{
    public class IssueManager
    {
        private IssueRecord[] issueList;
        private MemberManager memberManager;
        private IBookManager bookManager;
        public string LastErrorMessage { get; private set; } = string.Empty;
        private int count = 0;

        public IssueManager(int size, MemberManager memberManager, IBookManager bookManager)
        {
            issueList = new IssueRecord[size];
            this.memberManager = memberManager;
            this.bookManager = bookManager;
        }

        /// <summary>
        /// Checks whether there is space to add more Isssues.
        /// </summary>
        public bool HasCapacity()
        {
            int activeCount = 0;

            foreach (var issue in issueList)
            {
                if (issue != null && !issue.IsReturned)
                    activeCount++;
            }

            return activeCount < issueList.Length;
        }

        public bool IssueBook(string bookID, string memberID)
        {
            if(string.IsNullOrWhiteSpace(bookID) && string.IsNullOrWhiteSpace(memberID))
            {
                LastErrorMessage = "Invalid BookID or MemberID";
                return false;
            }

            Member member = memberManager.GetMemberByID(memberID);
            //Validate Book
            Book book = bookManager.FindBookByID(bookID);

            //Validate Member
            if (member == null)
            {
                LastErrorMessage = "Member Not Found";
                return false;
            }

            if(book == null)
            {
                LastErrorMessage = "Book Not Found";
                return false;
            }

            if (!member.CanIssueBook())
            {
                LastErrorMessage = "Member Has Reached Maximum Allowed issued Books";
                return false;
            }

            if (!book.IsAvailable)
            {
                LastErrorMessage = "Book is already issued";
                return false;
            }

            if (!HasCapacity())
            {
                LastErrorMessage = "Issue Limit Reached";
                return false;
            }

            //Find Empty Issue Slot 
            for(int i = 0; i < issueList.Length; i++)
            {
                if (issueList[i] == null)
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

            LastErrorMessage = "Unknown Error Occured";
            return false;
        }

        public string GetIssueID(string bookID, string memberID)
        {
            if (string.IsNullOrWhiteSpace(bookID) && string.IsNullOrWhiteSpace(memberID))
                return string.Empty;

            for(int i = 0; i < issueList.Length; i++)
            {
                IssueRecord record = issueList[i];

                if (record != null && record.BookID == bookID && record.MemberID == memberID && !record.IsReturned)
                {
                    return record.IssueID;
                }
            }
            return string.Empty;
        }

        public bool ReturnBook(string issueID)
        {
            if (string.IsNullOrWhiteSpace(issueID))
            {
                LastErrorMessage = "Issued ID is null or empty";
                return false;
            }

            for(int i = 0; i < issueList.Length; i++)
            {
                IssueRecord record = issueList[i];

                if(record != null && record.IssueID == issueID && !record.IsReturned)
                {
                    Book book = bookManager.FindBookByID(record.BookID);
                    Member member = memberManager.GetMemberByID(record.MemberID);

                    if (book == null)
                    {
                        LastErrorMessage = "Book not found";
                        return false;
                    }

                    if(member == null)
                    {
                        LastErrorMessage = "Member Not Found";
                        return false;
                    }

                    record.MarkAsReturned();
                    book.IsAvailable = true;
                    member.DecrementIssueCount();

                    return true;
                }
            }

            LastErrorMessage = "Unknown Error Occured";
            return false;
        }

        public IssueRecord[] GetAllActiveIssues()
        {
            return issueList;
        }
    }
}
