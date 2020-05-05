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

        Student GetOneStudent(long Id);

        void CreateNewStudent(StudentData studentData);

       
    }
}
