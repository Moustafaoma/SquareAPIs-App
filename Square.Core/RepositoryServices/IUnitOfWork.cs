using Square.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Square.Core.RepositoryServices
{
    public interface IUnitOfWork:IDisposable
    {
        IuserRepository Users { get; }
        IGenericRepository<Posts> Posts { get; }
        IGenericRepository<Likes> Likes { get; }
        IGenericRepository<Comments> Comments { get; }
        int Complete();

    }
}
