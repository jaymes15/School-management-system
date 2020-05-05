using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBWORK.DATA.Models.DataTarget;
using WEBWORK.Interfaces;

namespace WEBWORK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : Controller
    {
        public ICourse repo { get; }
        public CourseController( ICourse _repo)
        {
           
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
    }
}
