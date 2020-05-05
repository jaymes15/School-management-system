using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WEBWORK.DATA.DataContext;
using WEBWORK.DATA.Models.DataTarget;
using WEBWORK.Interfaces;

namespace WEBWORK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller 
    { 


        private ApplicationDbContext _context;
        public IStudent repo { get; }
        public StudentController(ApplicationDbContext context, IStudent _repo)
        {
            _context = context;
            repo = _repo;
        }


        #region Get All Student
        [HttpGet(Name = "GetAllStudent")]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]

        public IActionResult GetAllStudent()
        {
            return Ok(repo.GetAllStudent());
        }
        #endregion

        #region Get Student By Id
        [HttpGet("{id}",Name = "GetStudentById")]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]

        public IActionResult GetStudentById([FromRoute] long id)
        {
            var student = _context.Students.Find(id);
            if(student == null)
            {
                return NotFound(ModelState);
            }
            else
            {
                return Ok(repo.GetOneStudent(student));
            }

        }
        #endregion

        #region Create Student
        [HttpPost( Name = "CreateStudent")]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]

        public IActionResult CreateStudent([FromBody] StudentData studentData)
        {
           
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                repo.CreateNewStudent(studentData);
                return Ok();
            }
            
        }
#endregion

        #region Update Student
        [HttpPut("{id}",Name = "UpdateStudent")]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
     
        public IActionResult UpdateStudent([FromRoute] long id,[FromBody] StudentData studentData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else 
            {
                var student = _context.Students.Find(id);
                if (student == null)
                {
                    return NotFound(ModelState);
                }
                else
                {
                
                    return Ok(repo.UpdateStudent(student,studentData));
                }
                
            }

        }
        #endregion

        #region Delete Student
        [HttpDelete("{id}", Name = "DeleteStudent")]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]

        public IActionResult DeleteStudent([FromRoute] long id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
            {
                return NotFound(ModelState);
            }
            else
            {
                repo.DeleteStudent(student);
                return Ok();
             }

            }

        }
        #endregion

    }
