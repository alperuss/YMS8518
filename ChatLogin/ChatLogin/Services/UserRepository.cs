using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatLogin.Services
{
    public class UserRepository:Repository<Models.User>,Interfaces.IUserRepository
    {
        public UserRepository(DataContext dataContext) : base(dataContext) { }
    }
}
