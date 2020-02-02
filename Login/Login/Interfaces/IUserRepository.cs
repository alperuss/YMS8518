using Login.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
    }
}
