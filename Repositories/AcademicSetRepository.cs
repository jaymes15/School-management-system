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

        #region Create New AcademicSet
        public IEnumerable<AcademicSet> CreateNewAcademicSet(AcademicSetData academicData)
        {
            AcademicSet academicSet = academicData.academicSet;
            _context.AcademicSets.Add(academicSet);
            _context.SaveChanges();
            return _context.AcademicSets.ToList();

        }
        #endregion

        #region Delete AcademicSet
        public void DeleteAcademicSet(AcademicSet academicSet)
        {
            _context.AcademicSets.Remove(academicSet);
            _context.SaveChanges();
        }
        #endregion


        #region Get All Academic Set
        public IEnumerable<AcademicSet> GetAllAcademicSet()
        {
            return _context.AcademicSets.ToList();
        }
        #endregion

        #region Get One Academic Set

        public AcademicSet GetOneAcademicSet(AcademicSet academicSet)
        {
            return academicSet;
        }
        #endregion

        #region Update Academic Set
        public AcademicSet UpdateAcademicSet(AcademicSet academicSet, AcademicSetData academicSetData)
        {
            academicSet.Name = academicSetData.Name;
            academicSet.Entry = academicSetData.Entry;
            academicSet.Exit = academicSetData.Exit;
            _context.SaveChanges();
            return academicSet;
        }
        #endregion
    }
}
