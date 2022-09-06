using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace RI.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _context;
        protected readonly DbSet<T> _entities;

        public Repository(DbContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }

        public void Add(T entity)
        {
            _entities.Add(entity);
        }
        public void Remove(T entity)
        {
            _entities.Remove(entity);
        }
        public T Get(int id)
        {
            return _entities.Find(id);
        }
        public IEnumerable<T> GetAll()
        {
            return _entities.ToList();
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _entities.Where(predicate);
        }

    }
}
