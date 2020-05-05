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
    public class AcademicSetController : Controller
    {
        public IAcademicSet repo { get; }

        private ApplicationDbContext _context;
        public AcademicSetController(IAcademicSet _repo, ApplicationDbContext context)
        {

            repo = _repo;
            _context = context;
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

        #region Get AcademicSet By Id
        [HttpGet("{id}", Name = "GetAcademicSetById")]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]

        public IActionResult GetAcademicSetById([FromRoute] long id)
        {
            var academicSet = _context.AcademicSets.Find(id);
            if (academicSet == null)
            {
                return NotFound(ModelState);
            }
            else
            {
                return Ok(repo.GetOneAcademicSet(academicSet));
            }

        }
        #endregion

        #region Update Academic Set
        [HttpPut("{id}", Name = "UpdateAcademicSet")]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]

        public IActionResult UpdateAcademicSet([FromRoute] long id, [FromBody] AcademicSetData academicSetData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var academicSet = _context.AcademicSets.Find(id);
                if (academicSet == null)
                {
                    return NotFound(ModelState);
                }
                else
                {

                    return Ok(repo.UpdateAcademicSet(academicSet, academicSetData));
                }

            }

        }
        #endregion

        #region Delete Academic Set
        [HttpDelete("{id}", Name = "DeleteAcademicSet")]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]

        public IActionResult DeleteAcademicSet([FromRoute] long id)
        {
            var academicSet = _context.AcademicSets.Find(id);
            if (academicSet == null)
            {
                return NotFound(ModelState);
            }
            else
            {
                repo.DeleteAcademicSet(academicSet);
                return Ok();
            }

        }
        #endregion
    }
}
