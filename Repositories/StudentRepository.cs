using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBWORK.DATA.DataContext;
using WEBWORK.DATA.Models;
using WEBWORK.DATA.Models.DataTarget;
using WEBWORK.Interfaces;



namespace WEBWORK.Repositories
{
    public class StudentRepository : IStudent
    {
        private ApplicationDbContext _context;
        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        #region Create New Student
        public void CreateNewStudent(StudentData studentData)
        {
          
            Student student = studentData.Student;
            var set = _context.AcademicSets.Find(studentData.StudentAcademicSetId);
            student.AcademicSet= set;
            _context.Students.Add(student);
            _context.SaveChanges();
            
         
        }
        #endregion

        #region Delete Student
        public void DeleteStudent(Student student)
        {
            _context.Students.Remove(student);
            _context.SaveChanges();
        }
        #endregion

        #region Get All Student
        public IEnumerable<Student> GetAllStudent()
        {
            return _context.Students.Include(a => a.AcademicSet).ToList();
        }
        #endregion

        #region Get One Student
        public Student GetOneStudent(Student student)
        {
           
            return student;
        }
        #endregion

        #region Update Student
        public Student UpdateStudent(Student student, StudentData studentData)
        {
            student.FirstName = studentData.FirstName;
            student.LastName = studentData.LastName;
            student.Email = studentData.Email;
            student.Phone = studentData.Phone;
            student.StudentAcademicSetId = studentData.StudentAcademicSetId;
            var set = _context.AcademicSets.Find(studentData.StudentAcademicSetId);
            if (set != null)
            { 
                student.AcademicSet = set;
            }
           
            _context.SaveChanges();
            return student;
        }
        #endregion
    }
}
