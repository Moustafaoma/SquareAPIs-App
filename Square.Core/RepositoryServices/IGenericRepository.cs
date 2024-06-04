using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Square.Core.RepositoryServices
{
    public interface IGenericRepository<T> where T : class
    {
        T Get(int id);
        void Add(T item);
        void Delete(T item);
        IEnumerable<T> FindAll(params string[]includes);
        IEnumerable<T> FindAll();
        void Update(T item);
    }
}
