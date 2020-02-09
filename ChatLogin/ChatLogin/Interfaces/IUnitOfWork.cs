using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatLogin.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        DataContext GetDataContext();
        IUserRepository UserRepository { get; set; }
        IChatRepository ChatRepository { get; set; }
        int Complete();
    }
}
