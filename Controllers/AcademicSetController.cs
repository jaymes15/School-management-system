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
    public class AcademicSetController : Controller
    {
        public IAcademicSet repo { get; }
        public AcademicSetController(IAcademicSet _repo)
        {

            repo = _repo;
        }

        #region Create Academic Set
        [HttpPost(Name = "AcademicSet")]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]

        public IActionResult CreateAcademicSet([FromBody] AcademicSetData academicData)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {

                return Ok(repo.CreateNewAcademicSet(academicData));
            }

        }
        #endregion

        #region Get All AcademicSet
        [HttpGet(Name = "GetAllAcademicSet")]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]

        public IActionResult GetAllAcademicSet()
        {
            return Ok(repo.GetAllAcademicSet());
        }
        #endregion
    }
}
