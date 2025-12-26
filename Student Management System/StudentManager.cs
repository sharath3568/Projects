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
                    student.setStudentID = "STU" + (i + 1);
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

        public Student ViewStudent(string? studentID)
        {
            return FindStudentById(studentID);
        }

        public bool UpdateStudent(string? studentID,string newName, int newAge, float newMarks, Gender newGender)
        {
            Student student = FindStudentById(studentID);
            if (student == null)
                return false;

            student.SetName(newName);
            student.SetAge(newAge);
            student.SetMarks(newMarks);
            student.SetGender(newGender);
            return true;
        }

        public bool DeleteStudent(string studentID)
        {
            studentID = studentID.ToUpper();
            Student student = FindStudentById(studentID);
            if (student == null)
                return false;

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

        private Student? FindStudentById(string id)
        {
            id = id.ToUpper();
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i] != null && students[i].StudentID == id)
                    return students[i];
            }
            return null;
        }
    }
}
