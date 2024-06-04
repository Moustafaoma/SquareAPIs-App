using Square.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Square.Core.RepositoryServices
{
    public interface IuserRepository:IGenericRepository<Users>
    {
        Users GetUserByEmail(string email);
        Users GetUserByUserName(string username);
        void SignUp(Users user);
        Users SignOut();

    }
}
