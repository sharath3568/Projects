using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Library_Book_Management_System.UI.Helper
{
    internal class HelperUI
    {
        /// <summary>
        /// Ask User whether want to continue
        /// </summary>
        public static bool CheckRepeat(string management)
        {
            if(management == "BookManagement")
                Console.Write("\nDo you want to add another Book (Yes/No): ");

            if(management == "MemberManagement")
                Console.Write("\nDo you want to add another Member (Yes/No): ");

            if(management == "IssueManagement")
                Console.Write("\nDo you want to add another Issue (Yes/No): ");

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

        /// <summary>
        /// Validates text input (letters and spaces only).
        /// </summary>
        public static string CheckValidString()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input) && Regex.IsMatch(input, @"^[A-Za-z ]+$"))
                    return input;

                Console.Write("Invalid Input! Please try again : ");
            }
        }

        public static int CheckValidInt()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int temp) && temp > 0)
                    return temp;

                Console.Write("Invalid Input! Please try again : ");
            }
        }

        /// <summary>
        /// Gets a valid ID from user.
        /// </summary>
        public static string CheckID()
        {
            Console.Write("Enter ID : ");
            while (true)
            {
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                    return input.ToUpper();

                Console.Write("Invalid ID! Please try again : ");
            }
        }
    }
}
