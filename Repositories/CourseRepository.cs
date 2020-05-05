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
    public class CourseRepository : ICourse
    {

        private ApplicationDbContext _context;
        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Course> CreateNewCourses(CourseData courseData)
        {
           
                Course course = courseData.course;
                _context.Courses.Add(course);
                _context.SaveChanges();
                return _context.Courses.ToList();
          
        }

        public IEnumerable<Course> GetAllCourses()
        {
            return _context.Courses.ToList();
        }
    }
}
