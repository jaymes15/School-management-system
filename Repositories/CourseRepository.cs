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

        #region Create New Course
        public IEnumerable<Course> CreateNewCourses(CourseData courseData)
        {
           
                Course course = courseData.course;
                _context.Courses.Add(course);
                _context.SaveChanges();
                return _context.Courses.ToList();
          
        }
        #endregion

        #region Delete Course
        public void DeleteStudent(Course course)
        {
            _context.Courses.Remove(course);
            _context.SaveChanges();
        }
        #endregion

        #region Get All Courses
        public IEnumerable<Course> GetAllCourses()
        {
            return _context.Courses.ToList();
        }

        #endregion

        #region Get One Course
        public Course GetOneCourse(Course course)
        {
            return course;
        }
        #endregion


        #region Update Course
        public Course UpdateCourse(Course course, CourseData courseData)
        {
            course.Name = courseData.Name;
            course.CourseCode = courseData.CourseCode;
            _context.SaveChanges();
            return course;
        }
        #endregion
    }
}
