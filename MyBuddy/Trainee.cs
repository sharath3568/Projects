using System;
using System.Text.RegularExpressions;

namespace MyBuddy
{
    public class Trainee
    {
        public int PCNumber { get; set; }
        public string TraineeName { get; set; }
        public string PhoneNumber { get; set; }
        private string? emailID;
        private Gender traineeGender;
        public DateTime DateOfBirth { get; set; }

        public Trainee()
        {
            PCNumber = 1;
            TraineeName = "Default Name";
            PhoneNumber = "000-000-0000";
            EmailID = "abc@xyz.com";
            TraineeGender = Gender.OTHERS;
            DateOfBirth = new DateTime(2000, 1, 1);
        }

        public Trainee(int pcNumber, string traineeName, string phoneNumber, string? emailID, Gender traineeGender, DateTime dateOfBirth)
        {
            this.PCNumber = pcNumber;
            this.TraineeName = traineeName;
            this.PhoneNumber = phoneNumber;
            this.EmailID = emailID;
            this.TraineeGender = traineeGender;
            this.DateOfBirth = dateOfBirth;
        }

        public string? EmailID
        {
            get { return emailID; }
            set
            {
                if(Regex.IsMatch(value, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", RegexOptions.IgnoreCase))
                {
                    this.emailID = value;
                }
                else
                {
                    this.emailID = "Invalid Email ID";
                }
            }
        }

        public Gender TraineeGender
        {
            get { return traineeGender; }
            set
            {
                if(value == Gender.MALE || value == Gender.FEMALE || value == Gender.OTHERS)
                {
                    traineeGender = value;
                }
                else
                {
                    throw new ArgumentException("Invalid Gender");
                }
            }
        }

        public enum Gender
        {
            MALE, FEMALE, OTHERS
        }

        public string GetAllDetails()
        {
            return ($"PC Number : {PCNumber}\nTrainee Name : {TraineeName}\nPhone Number : {PhoneNumber}\nEmail ID : {EmailID}\nTrainee Gender : {TraineeGender}\nDate Of Birth : {DateOfBirth}");
        }
    }
}