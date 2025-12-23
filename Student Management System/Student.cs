using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System
{
    public class Student
    {
        public Guid StudentID { get; } // ✅ Identity: set once, never changed
        public string Name { get; private set; } // ✅ Readable outside, writable only inside class
        public int Age { get; private set; }
        public Gender Gender { get; private set; }
        public float Marks { get; private set; }

        public Student(Guid studentId, string name, int age, Gender gender, float marks)
        {
            StudentID = studentId;
            SetName(name);
            SetAge(age);
            SetGender(gender);
            SetMarks(marks);
        }

        public void SetAge(int age)
        {
            if (age > 0)
            {
                Age = age;
            }
            else
            {
                throw new ArgumentException("Age should be a non zero value");
            }
        }
        
        public void SetGender(Gender gender)
        {
            Gender = gender;
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name Cannot be empty");
            }
            else
            {
                Name = name;
            }
        }

        public void SetMarks(float marks)
        {
            if(marks < 0 || marks > 100)
            {
                throw new ArgumentException("Marks must be between 0 and 100");
            }
            else
            {
                Marks = marks;
            }
        }

        public void ViewStudent()
        {
            Console.WriteLine($"Student ID : {StudentID}\nName : {Name}\nAge : {Age}\nGender : {Gender}\nMarks : {Marks}");
        }
    }
}

public enum Gender
{
    Male, Female, Others
}
