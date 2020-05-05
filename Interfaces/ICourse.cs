using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBWORK.DATA.Models;
using WEBWORK.DATA.Models.DataTarget;

namespace WEBWORK.Interfaces
{
    public interface ICourse
    {

        IEnumerable<Course> CreateNewCourses(CourseData courseData);

        IEnumerable<Course> GetAllCourses();
    }
}
