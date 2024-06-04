using Square.Core.Models;
using Square.Core.RepositoryServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Square.EFCore.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IuserRepository Users { get; private set; }
        public IGenericRepository<Posts> Posts { get; private set; }

        public IGenericRepository<Likes> Likes { get; private set; }

        public IGenericRepository<Comments> Comments { get; private set; }
        private readonly ApplicationDBContext _context;
        public UnitOfWork(ApplicationDBContext context)
        {
            _context = context;
            Users = new userRepository(_context);
            Posts = new GenericRepository<Posts>(_context);
            Likes = new GenericRepository<Likes>(_context);
            Comments = new GenericRepository<Comments>(_context);


        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

        
    
}
