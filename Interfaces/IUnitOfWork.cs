using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBWORK.Interfaces
{
    public interface IUnitOfWork
    {
        IStudent student {get;}

        ICourse course { get; }

        void save();
    }
}
