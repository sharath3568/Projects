using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Student_Management_System
{
    public class StudentManager
    {
        private Student[] students;

        public StudentManager(int size)
        {
            students = new Student[size];
        }

        public bool AddStudent(Student student)
        {
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i] == null)
                {
                    students[i] = student;
                    return true;
                }
            }
            return false;
        }

        public bool HasCapacity()
        {
            return students.Contains(null);
        }

        public Student[] ViewStudent(string studentName, int studentAge)
        {
            return FindStudentByNameAge(studentName,studentAge);
        }

        public bool UpdateStudent(Guid studentID, string newName,int newAge, float newMarks)
        {
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i] != null && students[i].StudentID == studentID)
                {
                    students[i].SetName(newName);
                    students[i].SetAge(newAge);
                    students[i].SetMarks(newMarks);
                    return true;
                }
            }
            return false;
        }

        public bool DeleteStudent(string studentName, int studentAge)
        {
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i] != null && students[i].Name.Equals(studentName) && students[i].Age.Equals(studentAge))
                {
                    students[i] = null;
                    return true;
                }
            }
            return false;
        }

        private Student[] FindStudentByNameAge(string studentName, int studentAge)
        {
            Student[] studentDetails = new Student[students.Length];
            for(int i = 0; i < students.Length; i++)
            {
                if (students[i] != null && students[i].Name.Equals(studentName) && students[i].Age.Equals(studentAge))
                {
                    studentDetails[i] = students[i];
                }
            }
            return studentDetails;
        }
    }
}
