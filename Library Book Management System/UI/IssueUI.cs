using Library_Book_Management_System.Entities;
using Library_Book_Management_System.Managers;
using Library_Book_Management_System.UI.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Book_Management_System.UI
{
    internal class IssueUI
    {
        public static void IssueBook(IssueManager issueManager, MemberManager memberManager)
        {
            while (true)
            {
                Console.Write("Is the Member Existing. Yes/No ? : ");
                string input = Console.ReadLine();
                string memberID = "";
                if(string.Equals(input, "yes", StringComparison.OrdinalIgnoreCase))
                {
                    memberID = HelperUI.CheckID("Member");
                    bool isMemberExist = memberManager.MemberExists(memberID);
                    if (!isMemberExist)
                    {
                        Console.WriteLine($"Provided MemberID : {memberID} is not Found!");
                        continue;
                    }
                }
                else if (string.Equals(input, "No", StringComparison.OrdinalIgnoreCase))
                {
                    MemberUI.AddMember(memberManager, true);
                }
                else
                {
                    Console.Write("Invalid Input! Please try again : ");
                    continue;
                }

                HelperUI.CheckID("Member");
                string bookID = HelperUI.CheckID("Book");
                bool isIssued = issueManager.IssueBook(bookID, memberID);
                if (isIssued)
                {
                    Console.WriteLine("\nBook Issued Successfully");
                    string issueID = issueManager.GetIssueID(bookID, memberID);
                    Console.WriteLine($"Issue ID : {issueID}");
                    return;
                }
                else
                {
                    Console.WriteLine($"\nIssue Failed : {issueManager.LastErrorMessage}");
                    return;
                }
            }
        }

        public static void ReturnBook(IssueManager issueManager, MemberManager memberManager, BookManager bookManager)
        {
            while (true)
            {
                string memberID = HelperUI.CheckID("Member");
                if (memberManager.MemberExists(memberID))
                {
                    string bookID = HelperUI.CheckID("Book");
                    string issueID = issueManager.GetIssueID(bookID, memberID);
                    if (issueManager.ReturnBook(issueID))
                    {
                        Console.WriteLine("Book Returned Successfully!");
                        return;
                    }
                    else
                    {
                        Console.Write($"\nReturn Failed : {issueManager.LastErrorMessage}");
                        return;
                    }
                }
                else
                {
                    Console.Write($"Given MemberID : {memberID} does not exist! Please try again : ");
                }
            }
        }

        public static void ViewActiveIssues(IssueManager issueManager)
        {
            IssueRecord[] issues = issueManager.GetAllActiveIssues();

            bool hasIssues = false;
            Console.WriteLine();
            Console.WriteLine($"{"Issue ID",-8} | {"Member ID",-8} | {"Book ID",-8} | {"Issue Date",-10} | {"Return Date",-10} | {"Returned?", -10}");
            Console.WriteLine(new string('-', 58));
            foreach (IssueRecord Issue in issues)
            {
                if (Issue == null)
                    continue;

                if (Issue.IsReturned)
                    continue;

                hasIssues = true;

                Console.Write($"{Issue.IssueID,-8} | {Issue.MemberID,-8} | {Issue.BookID,-8} | {Issue.IssueDate,-10} | {Issue.ReturnDate,-10} | ");

                if (Issue.IsReturned)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{"Returned",-10}");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{"Not Returned",-10}");
                }

                Console.ResetColor();
            }

            if (!hasIssues)
                Console.WriteLine("No Issues available.");

            Console.WriteLine();
        }
    }
}
