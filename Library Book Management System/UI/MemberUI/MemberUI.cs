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

        public static void ViewAllMembers(MemberManager memberManager)
        {
            Member[] members = memberManager.ViewAllMembers();
            bool hasMembers = false;

            Console.WriteLine();
            Console.WriteLine($"{ "Member ID", -10} | { "Member Name", -30} | { "Maximum Allowed Books", -25} | { "Current Issued Count", -20}");
            
            foreach(var member in members)
            {
                if(member == null)
                    continue;
                hasMembers = true;

                Console.WriteLine($"{ member.MemberID, -10} | { member.Name, -30} | { member.MaxAllowedBooks, -25} | { member.CurrentIssuedCount, -20}");
            }

            if(!hasMembers)
                Console.WriteLine("No Members Found");

            Console.WriteLine();
        }

        public static void ViewMemberByID(MemberManager memberManager)
        {
            string memberID = HelperUI.CheckID();
            Member member = memberManager.GetMemberByID(memberID);

            if (member == null)
            {
                Console.WriteLine($"Provided Member ID : {memberID} is not found");
            }
            else
            {
                Console.WriteLine($"{"\nMember ID",-10} | {"Member Name",-30} | {"Maximum Allowed Books",-25} | {"Current Issued Count",-20}");
                Console.WriteLine(new string('-', 90));
                Console.WriteLine($"{member.MemberID,-10} | {member.Name,-30} | {member.MaxAllowedBooks,-25} | {member.CurrentIssuedCount,-20}");
            }
        }

        public static void DeleteMember(MemberManager memberManager)
        {
            string memberID = HelperUI.CheckID();
            bool isDeleted = memberManager.DeleteMember(memberID);

            if(isDeleted)
            {
                Console.WriteLine($"\nMember with ID : {memberID} is deleted successfully.\n");
            }
            else
            {
                Console.WriteLine($"\nFailed to delete Member with ID : {memberID}. It may not exist.\n");
            }
        }


    }
}
