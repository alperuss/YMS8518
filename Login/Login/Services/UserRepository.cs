using Login.Interfaces;
using Login.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login.Services
{
    public class UserRepository : Repository<User>, IUserRepository
    {

        public UserRepository(DataContext dataContext) : base(dataContext)
        {

        }

    }
}
