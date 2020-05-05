using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBWORK.DATA.DataContext;
using WEBWORK.DATA.Models.DataTarget;
using WEBWORK.Interfaces;

namespace WEBWORK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : Controller
    {
        public ICourse repo { get; }

        private ApplicationDbContext _context;
        public CourseController( ICourse _repo, ApplicationDbContext context)
        {
            _context = context;
            repo = _repo;
        }

        #region Create Course
        [HttpPost(Name = "CreateCourse")]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]

        public IActionResult CreateCourse([FromBody] CourseData courseData)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {

                return Ok(repo.CreateNewCourses(courseData));
            }

        }
        #endregion

        #region Get All Courses
        [HttpGet(Name = "GetAllCourses")]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]

        public IActionResult GetAllCourses()
        {
            return Ok(repo.GetAllCourses());
        }
        #endregion

        #region Get Course By Id
        [HttpGet("{id}", Name = "GetCourseById")]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]

        public IActionResult GetCourseById([FromRoute] long id)
        {
            var course = _context.Courses.Find(id);
            if (course == null)
            {
                return NotFound(ModelState);
            }
            else
            {
                return Ok(repo.GetOneCourse(course));
            }

        }
        #endregion

        #region Update Course
        [HttpPut("{id}", Name = "UpdateCourse")]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]

        public IActionResult UpdateCourse([FromRoute] long id, [FromBody] CourseData courseData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var course = _context.Courses.Find(id);
                if (course == null)
                {
                    return NotFound(ModelState);
                }
                else
                {

                    return Ok(repo.UpdateCourse(course, courseData));
                }

            }

        }
        #endregion

        #region Delete Course
        [HttpDelete("{id}", Name = "DeleteCourse")]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]

        public IActionResult DeleteCourse([FromRoute] long id)
        {
            var course = _context.Courses.Find(id);
            if (course == null)
            {
                return NotFound(ModelState);
            }
            else
            {
                repo.DeleteStudent(course);
                return Ok();
            }

        }
        #endregion
    }

}

