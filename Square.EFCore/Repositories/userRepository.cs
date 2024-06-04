using Square.Core.Models;
using Square.Core.RepositoryServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Square.EFCore.Repositories
{
    public class userRepository:GenericRepository<Users>,IuserRepository
    {
        private readonly ApplicationDBContext _context;
        public userRepository(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }

        public Users GetUserByEmail(string email)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email);
            return user;
        }

        public Users GetUserByUserName(string username)
        {
            var user = _context.Users.FirstOrDefault(u=>u.UserName == username);
            return user;
        }

        public Users SignOut()
        {
            throw new NotImplementedException();
        }

        public void SignUp(Users user)
        {
            throw new NotImplementedException();
        }
    }
}
