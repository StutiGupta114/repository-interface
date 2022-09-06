using RI.Model;
using RI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RI.UnitOfWork
{
    public interface IUnitOfWork
    {
        //if there are multiple entities, bind all entities that need to be interacted with
        IRepository<SampleClass> SampleRepository { get; }
        void Save();
        void Dispose();
    }
}
