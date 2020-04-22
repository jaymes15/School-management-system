using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WEBWORK.DATA.DataContext;

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


    }
}