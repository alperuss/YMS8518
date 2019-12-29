using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericRepositoryDeneme.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IStudentRepository StudentRepository { get; set; }
        int Complete();
    }
}
