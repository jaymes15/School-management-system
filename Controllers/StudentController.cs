using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WEBWORK.DATA.DataContext;
using WEBWORK.DATA.Models.DataTarget;

namespace WEBWORK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller 
    { 


        private ApplicationDbContext _context;
        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }


        #region Get All Student
        [HttpGet(Name = "GetAllStudent")]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]

        public IActionResult GetAllStudent()
        {
            return Ok(_context.Students.ToList());
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
                return Ok(student);
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
            var student = studentData.student;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                _context.Students.Add(student);
                _context.SaveChanges();
                return Ok(student);
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
                    student.FirstName = studentData.FirstName;
                    student.LastName = studentData.LastName;
                    student.Email = studentData.Email;
                    student.Phone = studentData.Phone;
                    _context.SaveChanges();
                    return Ok(student);
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
                _context.Students.Remove(student);
                _context.SaveChanges();
                return Ok();
             }

            }

        }
        #endregion

    }
