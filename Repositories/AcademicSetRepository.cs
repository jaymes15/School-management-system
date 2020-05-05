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
    public class AcademicSetRepository : IAcademicSet
    {
        private ApplicationDbContext _context;
        public AcademicSetRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<AcademicSet> CreateNewAcademicSet(AcademicSetData academicData)
        {
            AcademicSet academicSet = academicData.academicSet;
            _context.AcademicSets.Add(academicSet);
            _context.SaveChanges();
            return _context.AcademicSets.ToList();

        }

        public IEnumerable<AcademicSet> GetAllAcademicSet()
        {
            return _context.AcademicSets.ToList();
        }
    }
}
