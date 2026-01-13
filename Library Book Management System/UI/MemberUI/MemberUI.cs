using Library_Book_Management_System.Entities;
using Library_Book_Management_System.Managers;
using Library_Book_Management_System.UI.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Book_Management_System.UI.MemberUI
{
    internal class MemberUI
    {
        public static bool CheckRepeat()
        {
            Console.Write("\nDo you want to add another Member (Yes/No): ");
            while (true)
            {
                string input = Console.ReadLine();
                if (string.Equals(input, "Yes", StringComparison.OrdinalIgnoreCase))
                    return true;

                if (string.Equals(input, "No", StringComparison.OrdinalIgnoreCase))
                    return false;

                Console.Write("Invalid Input! Please try again : ");
            }
        }

        public static void AddMember(MemberManager memberManager)
        {
            while (true)
            {
                bool hasCapacity = memberManager.HasCapacity();
                if (!hasCapacity)
                {
                    Console.WriteLine("\nSlots are occupied");
                    return;
                }

                Console.Write("Member Name : ");
                string memberName = HelperUI.CheckValidString();

                Console.Write("Maximum Allowed Books");
                int maxAllowedBooks = HelperUI.CheckValidInt();

                Member member = new Member(memberName,maxAllowedBooks);

                if (memberManager.AddMember(member))
                {
                    Console.WriteLine("\nMember Added Successfully.\n");
                    Console.WriteLine($"\nMember ID : {member.MemberID}\nMember Name : {member.Name}\nMaximum Allowed Books : {member.MaxAllowedBooks}\nCurrent Issued Count : {member.CurrentIssuedCount}");
                }
                else
                {
                    Console.WriteLine("Failed to Add Member");
                    return;
                }

                if (!HelperUI.CheckRepeat("MemberManagement"))
                {
                    return;
                }
            }
        }


    }
}
