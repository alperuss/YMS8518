using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericRepositoryDeneme.Services
{
    public class StudentRepository:Repository<Models.Student>,Interfaces.IStudentRepository
    {
        private readonly DataContext _dataContext;
        public StudentRepository(DataContext dataContext):base(dataContext)
        {
            _dataContext = dataContext;
        }
    }
}
