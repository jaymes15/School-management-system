using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBWORK.Interfaces;

namespace WEBWORK.Repositories
{
    public class UnitOfWorkRepository : IUnitOfWork
    {
        public IStudent student => throw new NotImplementedException();

        public ICourse course => throw new NotImplementedException();

        public void save()
        {
            throw new NotImplementedException();
        }
    }
}
