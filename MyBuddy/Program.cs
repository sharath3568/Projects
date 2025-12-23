using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MyBuddy.Trainee;

namespace MyBuddy
{
    class Program
    {
        public static void Main()
        {
            MyBuddy myBuddy = new MyBuddy(4);

            Trainee trainee = new Trainee(101, "John Doe", "123-456-7890", "john.doe@example.com", Gender.MALE, new DateTime(2000, 7, 8));
            Trainee traineeOne = new Trainee(21, "David", "+91-9040444777", "David@infosys.com", Gender.MALE, new DateTime(1993, 07, 05));
            Trainee traineeTwo = new Trainee(92, "Iris", "+91-9050555777", "Iris@infosys.com", Gender.FEMALE, new DateTime(1990, 08, 05));
            Trainee traineeThree = new Trainee(14, "Daniel", "+91-9050555653", "Daniel@infosys.com", Gender.MALE, new DateTime(1990, 08, 05));

            myBuddy.AddMyBuddy(trainee);
            myBuddy.AddMyBuddy(traineeOne);
            myBuddy.AddMyBuddy(traineeTwo);
            myBuddy.AddMyBuddy(traineeThree);

            Trainee found = myBuddy.FindMyBuddy("David");
            if (found != null)
            {
                Console.WriteLine(found.GetAllDetails());
            }
            else
            {
                Console.WriteLine("Trainee not found");
            }
        }
    }
}
