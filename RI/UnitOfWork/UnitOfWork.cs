using RI.Model;
using RI.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RI.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly DbContext _context;
        public IRepository<SampleClass> SampleRepository => new Repository<SampleClass>(_context);
        public UnitOfWork(DbContext dbContext)
        {
            _context = dbContext;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
