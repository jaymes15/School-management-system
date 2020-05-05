using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBWORK.DATA.Models;
using WEBWORK.DATA.Models.DataTarget;

namespace WEBWORK.Interfaces
{
    public interface IStudent
    {
        IEnumerable<Student> GetAllStudent();

        Student GetOneStudent(Student student);

        void CreateNewStudent(StudentData studentData);

        Student UpdateStudent(Student student, StudentData studentdata);

        void DeleteStudent(Student student);

       
    }
}
