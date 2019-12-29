using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericRepository.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IUserRepository UserRepository { get; set; }
        IPetRepository PetRepository { get; set; }
        IBookRepositorycs BookRepositorycs { get; set; }
        int Complete();
    }
}
