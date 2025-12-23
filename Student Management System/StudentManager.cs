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
            if (FindStudentById(student.StudentID) != null) 
            {
                return false;
            }

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

        public Student ViewStudent(Guid studentID)
        {
            return FindStudentById(studentID);
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

        public bool DeleteStudent(Guid studentID)
        {
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i] != null && students[i].StudentID == studentID)
                {
                    students[i] = null;
                    return true;
                }
            }
            return false;
        }

        private Student? FindStudentById(Guid studentID)
        {
            for(int i = 0; i < students.Length; i++)
            {
                if (students[i] != null && students[i].StudentID.Equals(studentID))
                {
                    return students[i];
                }
            }
            return null;
        }
    }
}
