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
        public void CreateNewStudent(StudentData studentData)
        {
          
            Student student = studentData.Student;
            var set = _context.AcademicSets.Find(studentData.StudentAcademicSetId);
            student.AcademicSet= set;
            _context.Students.Add(student);
            _context.SaveChanges();
            
         
        }

        

        public IEnumerable<Student> GetAllStudent()
        {
            return _context.Students.Include(a => a.AcademicSet).ToList();
        }

        public Student GetOneStudent(long Id)
        {
            throw new NotImplementedException();
        }
    }
}
