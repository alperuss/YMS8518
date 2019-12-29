using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericRepository.Interfaces
{
    public interface IPetRepository: IRepository<Models.Pet>
    {
    }
}
