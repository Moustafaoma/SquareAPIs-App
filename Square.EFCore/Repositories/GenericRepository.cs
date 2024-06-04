using Microsoft.EntityFrameworkCore;
using Square.Core.RepositoryServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Square.EFCore.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDBContext _context;
        public GenericRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public void Add(T item)
        {
            _context.Set<T>().Add(item);
        }

        public void Delete(T item)
        {
            _context.Set<T>().Remove(item);
        }

        public IEnumerable<T> FindAll(params string[] includes)
        {
            IQueryable<T> qurey = _context.Set<T>();
            if (includes != null)
            {
                foreach (var item in includes)
                {
                    qurey = qurey.Include(item);
                }
            }
                return qurey.ToList();

        }

        public IEnumerable<T> FindAll()
        {
            return _context.Set<T>().ToList();
        }

        public T Get(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Update(T item)
        {
            _context.Set<T>().Update(item);
        }
    }
}
