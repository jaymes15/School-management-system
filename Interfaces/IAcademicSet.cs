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
    }
}
