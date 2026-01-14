using Library_Book_Management_System.Managers;
using Library_Book_Management_System.UI.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Book_Management_System.UI.IssueUI
{
    internal class IssueUI
    {
        public static void IssueBook(IssueManager issueManager, MemberManager memberManager)
        {
            Console.WriteLine("Is the Member Existing. Yes/No ?");
            while (true)
            {
                string input = Console.ReadLine();
                if (string.Equals(input, "Yes", StringComparison.OrdinalIgnoreCase)){
                    string memberID = HelperUI.CheckID();
                    bool isMemberExist = memberManager.MemberExists(memberID);
                    if (isMemberExist) {
                        bool canIssue = memberManager.CanIssueBook(memberID);
                        if(canIssue)
                        {
                            string bookID = HelperUI.CheckID();
                            bool isIssued = issueManager.IssueBook(bookID, memberID);
                            if (isIssued)
                            {
                                Console.WriteLine("\nBook Issued Successfully");
                                memberManager.IncrementIssuedCount(memberID);
                            }
                            else
                            {
                                Console.WriteLine("\nBook Issued Failed! Please try again");
                            }
                        }

                    }
                else if (string.Equals(input, "No", StringComparison.OrdinalIgnoreCase)){

                }
                else
                {
                    Console.Write("Invalid Input! Please try again : ");
                }
            }
        }
    }
}
