using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBWORK.DATA.Models;
using WEBWORK.DATA.Models.DataTarget;

namespace WEBWORK.Interfaces
{
    public interface IAcademicSet
    {
        IEnumerable<AcademicSet> CreateNewAcademicSet(AcademicSetData academicData);

        IEnumerable<AcademicSet> GetAllAcademicSet();

        AcademicSet GetOneAcademicSet(AcademicSet academicSet);

        AcademicSet UpdateAcademicSet(AcademicSet academicSet, AcademicSetData academicSetData);

        void DeleteAcademicSet(AcademicSet academicSet);
    }
}
