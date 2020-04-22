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

        [HttpGet(Name = "GetAllStudent")]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]

        public IActionResult GetAllStudent()
        {
            return Ok(_context.Students.ToList());
        }

        [HttpGet("{id}",Name = "GetStudentById")]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]

        public IActionResult GetStudentById([FromRoute] int id)
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



    }
}