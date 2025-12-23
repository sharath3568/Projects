using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBuddy
{
    public class MyBuddy
    {
        private Trainee[] TraineeList;
        public MyBuddy(int size)
        {
            TraineeList = new Trainee[size];
        }

        public void AddMyBuddy(Trainee trainee)
        {
            for (int i = 0; i < TraineeList.Length; i++)
            {
                if (TraineeList[i] == null)
                {
                    TraineeList[i] = trainee;
                    break;
                }
            }
        }

        public Trainee FindMyBuddy(string name)
        {
            Trainee trainee = new Trainee();
            for (int i = 0; i < TraineeList.Length; i++)
            {
                if (TraineeList[i] != null && TraineeList[i].TraineeName == name)
                {
                    trainee = TraineeList[i];
                    break;
                }
            }
            return trainee;
        }

        public Trainee[] FindMyBuddy(DateTime dateofBirth)
        {
            Trainee[] trainee = new Trainee[TraineeList.Length];
            int count = 0;
            for (int i = 0; i < TraineeList.Length; i++)
            {
                if (TraineeList[i] != null && TraineeList[i].DateOfBirth == dateofBirth)
                {
                    trainee[count] = TraineeList[i];
                    count++;
                }
            }
            return trainee;
        }

        public Trainee[] FindMyBuddy(DateTime startDate, DateTime endDate)
        {
            Trainee[] trainee = new Trainee[TraineeList.Length];
            int count = 0;
            for (int i = 0; i < TraineeList.Length; i++)
            {
                if (TraineeList[i].DateOfBirth >= startDate && TraineeList[i].DateOfBirth <= endDate)
                {
                    trainee[count] = TraineeList[i];
                    count++;
                }
            }
            return trainee;
        }
    }
}
